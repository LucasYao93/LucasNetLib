using System;
using System.IO.Ports;

namespace ModbusRTUSender
{
    class Program
    {
        static void Main(string[] args)
        {

            // 设置串口参数
            SerialPort serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);

            serialPort.DataReceived += DataReceivedEventHandler;

            bool wiatRecive = false;
            try
            {
                // 打开串口
                serialPort.Open();

                // 准备发送的Modbus RTU消息
                byte slaveAddress = 1;
                byte functionCode = 1;
                ushort startAddress = 0;
                ushort numRegisters = 9;
                byte[] message = BuildModbusRTUMessage(slaveAddress, functionCode, startAddress, numRegisters);

                var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (sender, eventAgs) => cts.Cancel();

                serialPort.Write(message, 0, message.Length);
                Console.WriteLine("Modbus RTU message sent...!");

                //// 发送消息
                //var sendTask = Task.Run(() =>
                //{
                //    while(!cts.Token.IsCancellationRequested)
                //    {
                //        serialPort.Write(message, 0, message.Length);
                //        Console.WriteLine("Modbus RTU message sent...!");

                //        //Task.Delay(2000).Wait();

                //        if (cts.Token.IsCancellationRequested)
                //        {
                //            serialPort.Close();
                //            break;
                //        }
                //    }

                //}); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // 关闭串口
                //serialPort.Close();
            }

            Console.ReadLine();
        }

        // 构建Modbus RTU消息
        static byte[] BuildModbusRTUMessage(byte slaveAddress, byte functionCode, ushort startAddress, ushort numRegisters)
        {
            byte[] message = new byte[8];

            message[0] = slaveAddress;
            message[1] = functionCode;
            message[2] = (byte)(startAddress >> 8);  // 高位字节
            message[3] = (byte)(startAddress & 0xFF);  // 低位字节
            message[4] = (byte)(numRegisters >> 8);  // 高位字节
            message[5] = (byte)(numRegisters & 0xFF);  // 低位字节

            // 计算并填充CRC校验
            ushort crc = CalculateCRC(message, 6);
            message[6] = (byte)(crc & 0xFF);  // 低位字节
            message[7] = (byte)(crc >> 8);  // 高位字节

            return message;
        }

        // 计算CRC校验
        static ushort CalculateCRC(byte[] data, int length)
        {
            ushort crc = 0xFFFF;

            for (int i = 0; i < length; ++i)
            {
                crc ^= data[i];

                for (int j = 0; j < 8; ++j)
                {
                    if ((crc & 0x0001) == 0x0001)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }

            return crc;
        }

        // 验证CRC校验
        static bool ValidateCRC(byte[] data)
        {
            if (data.Length < 2)
                return false;

            ushort crc = CalculateCRC(data, data.Length - 2);
            ushort receivedCRC = (ushort)((data[data.Length - 1] << 8) | data[data.Length - 2]);

            return crc == receivedCRC;
        }

        static void DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;
            int bytesToRead = serialPort.BytesToRead;

            byte[] buffer = new byte[bytesToRead];

            serialPort.Read(buffer, 0, bytesToRead);

            if (ValidateCRC(buffer))
            {
                // CRC校验通过，继续处理数据
                // TODO: 解析Modbus消息并执行相应操作
                Console.WriteLine("Received data is valid.");
            }
            else
            {
                // CRC校验失败，丢弃数据或进行错误处理
                Console.WriteLine("Received data is corrupted or modified.");
            }
        }

        void TimerCallback(object? state)
        {
            if (state == null) return;

        }
    }
}
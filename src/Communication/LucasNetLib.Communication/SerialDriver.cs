using System.IO.Ports;
using System.Net.Http.Headers;
namespace LucasNetLib.Communication;

/// <summary>
/// 串口驱动
/// </summary>
public class SerialDriver : CommDriverBaseAbstract
{
    /// <summary>
    /// <see cref="System.IO.Ports.SerialPort"/>
    /// </summary>
    public SerialPort Port { get; protected set; }

    public string PortName { get; set; }

    public int Baudrate { get; set; }

    public int DataBits { get; set; }

    public int StopBits { get; set; }

    public override bool Active
    {
        get
        {
            if (Port == null) { return false; }
            return Port.IsOpen;
        }
    }

    private bool _IsFixedError = false;

    public override bool Open()
    {
        if (base.Enabled)
        {
            if (Active) Close();
            return false;
        }
        if (Port == null || !Port.IsOpen)
        {
            Port = new SerialPort(PortName);
            Port.DataReceived += Port_DataReceived;
            Port.BaudRate = Baudrate;
            Port.StopBits = (System.IO.Ports.StopBits)StopBits;
            Port.Parity = System.IO.Ports.Parity.None;
            if (DataBits == 6) //6 Bit作为异常处理啊
            {
                _IsFixedError = true;
                Port.DataBits = 8;
            }
            else Port.DataBits = DataBits;
            Port.RtsEnable = true;
            Port.Open();
            return Port.IsOpen;
        }
        return false;
    }

    void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        if (Port == null) return;
        int count = Port.BytesToRead;
        int lastCount = -1;
        while (lastCount < count)
        {
            if (lastCount > 1000) break;
            Thread.Sleep(ReceiveTimeInterval);
            lastCount = count;
            count = Port.BytesToRead;
        }
        byte[] b = new byte[Port.BytesToRead];
        Port.Read(b, 0, b.Length);
        DataReceivedEventArgs arg = new DataReceivedEventArgs();
        if (_IsFixedError)
        {
            int len = b.Length;
            var bufConvert = new byte[len];
            for (int i = 0; i < len; ++i)
            {
                bufConvert[i] = (byte)(b[i] & 0x7F);
            }
            arg.Buffer = bufConvert;
        }
        else arg.Buffer = b;
        DataReceived(arg);
    }

    public override bool Close()
    {
        if (Port == null) return false;
        //Port.DataReceived -= new Port.CommEvent(port_DataReceived);
        Port.Close();
        return !Port.IsOpen;
    }

    /// <summary>
    /// send data by com port.
    /// </summary>
    /// <param name="buf"></param>
    /// <returns></returns>
    public override bool SendData(byte[] buf)
    {
        if (Port == null) return false;
        if (buf == null || buf.Length <= 0) return false;
        int len = buf.Length;
        if (_IsFixedError)
        {
            var bufConvert = new byte[len];
            for (int i = 0; i < len; ++i)
            {
                bufConvert[i] = (byte)(buf[i] | 0x80);
            }
            Port.Write(bufConvert, 0, len);
        }
        else Port.Write(buf, 0, len);
        return true;
    }

    /// <summary>
    /// data received.
    /// </summary>
    /// <param name="buf"></param>
    protected override void DataReceived(DataReceivedEventArgs args)
    {
        base.DataReceived(args);
    }
}

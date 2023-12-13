namespace LucasNetLib.Communication;

/// <summary>
/// 数据接收委托
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
public delegate void DataRecivedEventHandler(object sender, DataReceivedEventArgs e);

/// <summary>
/// 通信设备基础类
/// </summary>
public abstract class CommDriverBaseAbstract
{
    /// <summary>
    /// 数据接收事件
    /// </summary>
    public event DataRecivedEventHandler OnDataRecived;

    /// <summary>
    /// 无参构造函数
    /// </summary>
    public CommDriverBaseAbstract()
    {
    }

    /// <summary>
    /// 指令处理间隔
    /// </summary>
    public int ReceiveTimeInterval { get; set; }

    /// <summary>
    /// 指令发送间隔
    /// </summary>
    public int SendTimeInterval { get; set; }

    /// <summary>
    /// 指令超时
    /// </summary>
    public int SendTimeOut { get; set; }

    /// <summary>
    /// 端口是否启用
    /// </summary>
    public bool Enabled { get; set; } = false;

    /// <summary>
    /// ？
    /// </summary>
    public virtual bool Active { get { return false; } }

    /// <summary>
    /// 端口打开
    /// </summary>
    public virtual bool Open()
    {
        return false;
    }

    /// <summary>
    /// 端口关闭
    /// </summary>
    public virtual bool Close()
    {
        return false;
    }

    /// <summary>
    /// 发送数据
    /// </summary>
    /// <param name="buf"></param>
    /// <returns></returns>
    public virtual bool SendData(byte[] buf)
    {
        return false;
    }

    protected virtual void DataReceived(DataReceivedEventArgs args)
    {
        if (OnDataRecived != null)
        {
            if (args == null) args = new DataReceivedEventArgs();
            OnDataRecived(this, args);
        }
    }
}

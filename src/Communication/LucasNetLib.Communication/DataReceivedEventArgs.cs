namespace LucasNetLib.Communication;

/// <summary>
/// 数据接收参数对象
/// </summary>
public class DataReceivedEventArgs : EventArgs
{
    public object Tag { get; set; }
    /// <summary>
    /// data buffer.
    /// </summary>
    public byte[] Buffer { get; set; }
}

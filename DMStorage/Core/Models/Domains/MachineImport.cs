
namespace DMStorage.Core.Models.Domains
{
    public class MachineImport
    {
        public string MachineName { get; set; }
        public string Ip { get; set; }
        public string MacAdress { get; set; }
        public string Port { get; set; }
        public string DMCZ_Connection { get; set; }
        public string OPC_Driver { get; set; }
        public string OPC_PLC { get; set; }
        public string Original_PLC { get; set; }
        public string VLan { get; set; }
        public string DepartmentName { get; set; }
    }
}

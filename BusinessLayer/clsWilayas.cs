using System;
using System.Data;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
    public class clsWilayas
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public int? WlID { get; set; }
        public string Nm { get; set; }

        public clsWilayas()
        {
            _Mode = enMode.AddNew;
            WlID = null;
            Nm = "";
        }

        private clsWilayas(int? WlID, string Nm)
        {
            _Mode = enMode.Update;
            this.WlID = WlID;
            this.Nm = Nm;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNew())
                        {
                            _Mode = enMode.AddNew;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        private bool _AddNew()
        {
            this.WlID = clsWilayasData.AddNew(this.Nm);
            return WlID != null;
        }

        private bool _Update() 
            => clsWilayasData.Update(this.WlID, this.Nm);

        public static bool Delete(int WlID) => clsWilayasData.Delete(WlID);

        public static DataTable GetAllWilayas() => clsWilayasData.GetAllWilayas();

        public static clsWilayas Find(int? WlID)
        {
            string Nm = "";

            return (clsWilayasData.GetByID(WlID, ref Nm)) ?
                new clsWilayas(WlID, Nm) : null;
        }

        public static clsWilayas Find(string Nm)
        {
            int? WlID = null;

            return (clsWilayasData.GetByName(Nm , ref WlID)) ?
                new clsWilayas(WlID, Nm) : null;
        }

    }
}


using System;
using System.Data;
using System.Threading.Tasks;
using DataLayer;
namespace BusinessLayer
{
    public class clsPeople
    {
        public enum enMode : byte { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public enum enGender : byte { Male = 0 , Female  = 1 }
        public enGender Gndr { get; set; }
        public int? PrsnID { get; set; }
        public string CrdID { get; set; }
        public string FrstNm { get; set; }
        public string MddlNm { get; set; }
        public string LstNm { get; set; }
        public DateTime DBrth { get; set; }
        public string Addrs { get; set; }
        public string Phn { get; set; }
        public string Eml { get; set; }
        public int? WlID { set; get; }
        public string ImgPth { get; set; }

        public clsWilayas WilayaInfo;

        public string FullName
            => (MddlNm == null) ? string.Join(" ", FrstNm, LstNm) : string.Join(" ", FrstNm, MddlNm, LstNm);

        public string Gender =>
            Gndr.ToString();

        public clsPeople()
        {
            _Mode = enMode.AddNew;
            PrsnID = null;
            CrdID = "";
            FrstNm = "";
            MddlNm = null;
            LstNm = "";
            DBrth = DateTime.Now;
            Gndr = enGender.Male;
            Addrs = "";
            Phn = "";
            Eml = null;
            WlID = null;
            ImgPth = null;
        }

        private clsPeople(int? PrsnID, string CrdID, string FrstNm, string MddlNm, string LstNm, DateTime DBrth, enGender Gndr, string Addrs, string Phn, string Eml, int WlID, string ImgPth)
        {
            _Mode = enMode.Update;
            this.PrsnID = PrsnID;
            this.CrdID = CrdID;
            this.FrstNm = FrstNm;
            this.MddlNm = MddlNm;
            this.LstNm = LstNm;
            this.DBrth = DBrth;
            this.Gndr = Gndr;
            this.Addrs = Addrs;
            this.Phn = Phn;
            this.Eml = Eml;
            this.WlID = WlID;
            this.ImgPth = ImgPth;
            WilayaInfo = clsWilayas.Find(WlID);
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
            this.PrsnID = clsPeopleData.AddNewPerson(this.CrdID, this.FrstNm, this.MddlNm, this.LstNm, this.DBrth, (byte)this.Gndr, this.Addrs, this.Phn, this.Eml, this.WlID, this.ImgPth);
            return PrsnID != null;
        }

        private bool _Update()
            => clsPeopleData.UpdatePerson(this.PrsnID, this.CrdID, this.FrstNm, this.MddlNm, this.LstNm, this.DBrth, (byte)this.Gndr, this.Addrs, this.Phn, this.Eml, this.WlID, this.ImgPth);

        public static bool Delete(int PrsnID)
            => clsPeopleData.Delete(PrsnID);

        public static DataTable GetAllPeople() 
            => clsPeopleData.GetAllPeople();

        public static clsPeople Find(int? PrsnID)
        {
            string CrdID = "";
            string FrstNm = "";
            string MddlNm = null;
            string LstNm = "";
            DateTime DBrth = DateTime.Now;
            byte Gndr = 0;
            string Addrs = "";
            string Phn = "";
            string Eml = "";
            int WlID = 0;
            string ImgPth = null;

            return (clsPeopleData.GetByID(PrsnID, ref CrdID, ref FrstNm, ref MddlNm, ref LstNm, ref DBrth, ref Gndr, ref Addrs, ref Phn, ref Eml, ref WlID, ref ImgPth)) ?
                new clsPeople(PrsnID, CrdID, FrstNm, MddlNm, LstNm, DBrth, (enGender)Gndr, Addrs, Phn, Eml, WlID, ImgPth) : null;
        }

        public static clsPeople Find(string CrdID)
        {
            int? PrsnID = null;
            string FrstNm = "";
            string MddlNm = null;
            string LstNm = "";
            DateTime DBrth = DateTime.Now;
            byte Gndr = 0;
            string Addrs = "";
            string Phn = "";
            string Eml = "";
            int WlID = 0;
            string ImgPth = null;

            return (clsPeopleData.GetByCardID(CrdID, ref PrsnID, ref FrstNm, ref MddlNm, ref LstNm, ref DBrth, ref Gndr, ref Addrs, ref Phn, ref Eml, ref WlID, ref ImgPth)) ?
                new clsPeople(PrsnID, CrdID, FrstNm, MddlNm, LstNm, DBrth, (enGender)Gndr, Addrs, Phn, Eml, WlID, ImgPth) : null;
        }

        public static int? GetIDByEmail(string Email)
            => clsPeopleData.GetPersonIDByEmail(Email);

        public static int? GetIDByPhone(string Phone)
            => clsPeopleData.GetPersonIDByPhone(Phone);

        public static bool IsPerson(int? PersonID , Predicate<int?> PersonType)
            => PersonType(PersonID);

        public static DataTable GetAllPeoplePerPages(int NumberPage, int SizePage)
            => clsPeopleData.GetAllPeoplePerPages(NumberPage, SizePage);

        public static DataTable GetPeoplePerPagesBy<T>(int PageNumber, int PageSize, string Parameter, T Value)
            => clsPeopleData.GetPeoplePerPagesBy(PageNumber, PageSize, Parameter, Value);
        
        public static int? GetTotalPages(int PageSize)
            => clsPeopleData.GetTotalPages(PageSize);

        public static int? GetTotalPagesBy<T>(int PageSize, string Parameter, T Value)
            => clsPeopleData.GetTotalPagesPeopleBy(PageSize, Parameter, Value);

        public static bool IsPersonExistByCardID(string CardID)
            => clsPeopleData.IsPersonExistByCardID(CardID);

        public static bool IsPersonExistByEmail(string Email)
            => clsPeopleData.IsPersonExistByEmail(Email);

        public static bool IsPersonExistByPhone(string Phone)
            => clsPeopleData.IsPersonExistByPhone(Phone);


    }
}


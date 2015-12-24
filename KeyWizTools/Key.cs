namespace KeyWizTools
{
    public class Key
    {
        public Key()
        { }
        public Key(string keysymbol, string keydeposit, string mastersystemname, string keyserial, string employeeid)
        {
            Keysymbol = keysymbol;
            Keydeposit = keydeposit;
            Mastersystemname = mastersystemname;
            Keyserial = keyserial;
            Employeeid = employeeid;
        }

        public string Keysymbol { get; set; }
        public string Keydeposit { get; set; }
        public string Mastersystemname { get; set; }
        public string Keyserial { get; set; }
        public string Employeeid { get; set; }

        public override string ToString()
        {
            return Employeeid + " " + Keysymbol + " " + Keyserial + " " + Keydeposit + " " + Mastersystemname + " ";
        }
    }
}

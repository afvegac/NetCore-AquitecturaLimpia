using System;
namespace RealEstate.Entities.Utilitarios
{
    public class ResponseGeneric
    {
        public ResponseGeneric()
        {
            Data = null;
            Success = false;
            Message = "";
            Status = "";
        }

        public object Data { set; get; }
        public bool Success { set; get; }
        public string Message { set; get; }
        public string Status { set; get; }
    }
}


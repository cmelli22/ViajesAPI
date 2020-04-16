using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViajesAPI.Reponse
{
    public class BaseResponse<TEntity> where TEntity: class
    {
        public bool status { get; set; }
        public string message { get; set; }
        public TEntity data { get; set; }
        public IList<TEntity> dataList { get; set; }

        public BaseResponse(string message)
        {
            status = false;
            this.message = message;
            dataList = null;
            data = null;
        }

        public BaseResponse(IList<TEntity> dataList )
        {
            status = true;
            this.message = "La opreacion se realizo con exito";
            this.dataList = dataList;
            data = null;
        }

        public BaseResponse(TEntity data)
        {
            status = true;
            this.message = "La opreacion se realizo con exito";
            this.dataList = null;
            this.data = data;
        }
    }
}

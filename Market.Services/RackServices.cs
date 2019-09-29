using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Contract;
using Market.Entities.Interfaces;
using Market.Entities.ShouldMap;

namespace Market.Services
{
    public class RackServices 
    {
        private IRackRepository IRackRepository { get; set; }

        
        public void CreateAndDelete(RackContract rackContract)
        {
            var rack = IRackRepository.Get(rackContract.Id);
            if (rack != null)
            {
                rack.Limit = rackContract.Limit;
                rack.Location = rackContract.Location;
                rack.Name = rackContract.Name;
                rack.Code = rackContract.Code;
                rack.Rack1 = IRackRepository.Get(rackContract.RackId);
            }
            else
            {
                Rack rack1 = new Rack();

                rack1.Limit = rackContract.Limit;
                rack1.Location = rackContract.Location;
                rack1.Name = rackContract.Name;
                rack1.Code = rackContract.Code;
                rack1.Rack1 = IRackRepository.Get(rackContract.RackId);

                IRackRepository.Insert(rack1);
            }
        }

        public void Delete(RackContract rackContract)
        {
            var raCk = IRackRepository.Get(rackContract.Id);
            IRackRepository.Delete(raCk);
        }
    }
}

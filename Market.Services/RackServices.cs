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

        private IRackItemLevelRepository irackItemLevelRepository { get; set; }
        public void CreateAndDelete(RackContract rackContract)
        {
            var rack = IRackRepository.Get(rackContract.Id);
            if (rack != null)
            {
                rack.Limit = rackContract.Limit;
                rack.Location = rackContract.Location;
                rack.Name = rackContract.Name;
                rack.Rack1 = IRackRepository.Get(rackContract.RackId);
            }
        }
    }
}

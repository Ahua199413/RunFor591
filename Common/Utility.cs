﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunFor591.DataBase;

namespace RunFor591.Common
{
    public static class Utility
    {
        //依據名稱，取得region或section的id
        public static string GetLocationIdByName(string name)
        {
            var locationEntity = LocationJson.GetInstance();
            var region = locationEntity.regionEntity.region.FirstOrDefault(x=>x.txt==name);
            if (region != null)
                return region.id;
            foreach (var reg in locationEntity.regionEntity.region)
            {
                foreach (var section in reg.section)
                {
                    if (section.name == name)
                        return section.id;
                } 
            }
            throw new ArgumentException("Cannot find name in Region.json  name:"+name);
        }

        //依據捷運線或捷運站名稱，取得id
        public static string GetMrtIdByName(string name)
        {
            var locationEntity = LocationJson.GetInstance();
            foreach (var mrt in locationEntity.mrtEntity.mrts)
            {

                foreach (var mrtline in mrt.mrtline)
                {
                    if (mrtline.name == name)
                        return mrtline.sid;
                    foreach (var station in mrtline.station)
                    {
                        if (station.name == name)
                            return station.nid;
                    }
                }
            }
            throw new ArgumentException("Cannot find name in mrt.json name:"+name);

            
        }

    }
}

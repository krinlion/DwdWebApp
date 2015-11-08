using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    /// <summary>
    /// 소그룹 멤버 정보
    /// </summary>
    public class SmallGroupInfoViewModel
    {
        public class ShortInfo
        {
            public string Name { get; set; }

            public string PhoneNumber { get; set; }
        }

        /// <summary>
        /// 리더 정보
        /// </summary>
        public MemberInfo LeaderInfo { get; set; }
        /// <summary>
        /// 소그룹 멤버 정보
        /// </summary>
        public List<ShortInfo> MemerList { get; set; }
    }
}

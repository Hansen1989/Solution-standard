using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Utilities.Constants
{
    /// <summary>
    /// 常量
    /// </summary>
    public class SubsonicConstants
    {
        /// <summary>
        /// 状态-存档
        /// </summary>        
        public const int STATUS_NEW = 1;

        /// <summary>
        /// 核准
        /// </summary>
        public const int STATUS_APPROVED = 2;

        /// <summary>
        /// 作废
        /// </summary>
        public const int STATUS_ABANDON = 3;

        /// <summary>
        /// 关单(月结)
        /// </summary>
        public const int STATUS_CLOSED = 5;
    }
}

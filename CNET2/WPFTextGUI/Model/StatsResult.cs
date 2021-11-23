using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTextGUI.Model
{
    /// <summary>
    /// Result of frequential analysis from given source
    /// </summary>
    internal class StatsResult
    {
        /// <summary>
        /// source text for analysis
        /// </summary>
        public string Source { get; set; } 
        
        /// <summary>
        /// 1 0most common words in source
        /// </summary>
        public Dictionary<string, int> Top10Words { get; set; }   
    }
}

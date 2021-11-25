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
    public class StatsResult
    {
        public int Id { get; set; }
        /// <summary>
        /// source text for analysis
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Name if applicable (book title etc)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// how long was the analysis running
        /// </summary>
        public int ElapsedMilliseconds { get; set; }
		
        /// <summary>
        /// 1 0most common words in source
        /// </summary>
        public Dictionary<string, int> Top10Words { get; set; }

        /// <summary>
        /// Who submitted this statsResults
        /// </summary>
        public string SubmitedBy { get; set; }
    }
}

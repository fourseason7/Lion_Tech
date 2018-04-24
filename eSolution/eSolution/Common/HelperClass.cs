using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSolution.Database;

namespace eSolution
{
    class HelperClass
    {
        private static eSolutionDataContext m_eSolutionEntities;
        public static string CodeName
        {
            get { return "ValueMember"; }
        }
        public static string DisplayName
        {
            get { return "DisplayMember"; }
        }

        protected static eSolutionDataContext MESEntities
        {
            get
            {
                if (m_eSolutionEntities == null)
                {
                    m_eSolutionEntities = new eSolutionDataContext();

                }
                return m_eSolutionEntities;
            }
        }

    }
}

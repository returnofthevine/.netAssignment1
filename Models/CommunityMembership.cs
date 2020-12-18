﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class CommunityMembership
    {
        public int ID
        {
            set;
            get;
        }

        public int StudentID
        {
            set;
            get;
        }

        public string CommunityID
        {
            set;
            get;
        }

        public Student Student
        {
            get;
            set;
        }

        public Community Community
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace NbaScore.Model.Entities
{
    class Meta
    {
        int total_pages;
        int current_page;
        int? next_page;
        int per_page;
        int total_count;

        public Meta() { }
        public Meta(int total_pages,
        int current_page,
        int? next_page,
        int per_page,
        int total_count) 
        {
            this.per_page = per_page;
            this.total_count = total_count;
            this.total_pages = total_pages;
            this.current_page = current_page;
            this.next_page = next_page;
        }

        public int Total_pages { get => total_pages; private set { } }
        public int Current_page { get => current_page; private set { } }
        public int? Next_page { get => next_page; private set { } }
        public int Per_page { get => per_page; private set { } }
        public int Total_count { get => total_count; private set { } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Entity
{
    public class CheckBoxItem<T>
    {
        public CheckBoxItem() { }

        public CheckBoxItem(T ID, T ParentID, String Text)
        {
            this.ID = ID;
            this.ParentID = ParentID;
            this.Text = Text;
        }

        public T ID { get; set; }

        public T ParentID { get; set; }

        public String Text { get; set; }

        public override string ToString()
        {
            return String.Format("<li><input type=check ID=\"{0}\" data-parent-id=\"{1}\" />{2}", this.ID, this.ParentID, this.Text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_Forms.NavigationBsps.Flyout
{
    //Model-Definition für Flyout-Menüeinträge
    public class FlyoutMenuFlyoutMenuItem
    {
        public FlyoutMenuFlyoutMenuItem()
        {
            TargetType = typeof(FlyoutMenuFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
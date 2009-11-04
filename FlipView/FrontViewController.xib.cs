
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FlipView
{
	public partial class FrontViewController : UIViewController
	{
		#region Constructors

		// The IntPtr and NSCoder constructors are required for controllers that need 
		// to be able to be created from a xib rather than from managed code

		public FrontViewController (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public FrontViewController (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public FrontViewController () : base("FrontViewController", null)
		{
			Initialize ();
		}

		void Initialize ()
		{
		}
		
		#endregion
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			UIImage image = UIImage.FromFile("johnskeet.jpg");
			UIImageView firstImage = new UIImageView(image);
			image.Dispose();
			firstImage.Frame = UIScreen.MainScreen.Bounds;
			this.View.AddSubview(firstImage);
			firstImage.Dispose();
		}
		
		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
			
			BackViewController bvc = new BackViewController(this);
			bvc.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
			PresentModalViewController(bvc, true);
		}


		
	}
}

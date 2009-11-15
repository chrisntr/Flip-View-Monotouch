
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FlipView
{
	public partial class BackViewController : UIViewController
	{
		FrontViewController _fvc = new FrontViewController();
		
		#region Constructors

		// The IntPtr and NSCoder constructors are required for controllers that need 
		// to be able to be created from a xib rather than from managed code

		public BackViewController (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public BackViewController (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public BackViewController (FrontViewController fvc) : base("BackViewController", null)
		{
			this._fvc = fvc;
			Initialize ();
		}

		void Initialize ()
		{
		}
		
		#endregion
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			using(UIImage image = UIImage.FromFile("notjohnskeet.jpg"))
			{
				using(UIImageView secondImageView = new UIImageView(image))
				{
					secondImageView.Frame = UIScreen.MainScreen.Bounds;
					this.View.AddSubview(secondImageView);
				}
			}
		}
		
		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
			_fvc.DismissModalViewControllerAnimated(true);
		}


		
	}
}

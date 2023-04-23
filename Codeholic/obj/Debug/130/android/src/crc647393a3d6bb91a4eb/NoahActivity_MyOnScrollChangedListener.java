package crc647393a3d6bb91a4eb;


public class NoahActivity_MyOnScrollChangedListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.ViewTreeObserver.OnScrollChangedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScrollChanged:()V:GetOnScrollChangedHandler:Android.Views.ViewTreeObserver/IOnScrollChangedListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Codeholic.NoahActivity+MyOnScrollChangedListener, Codeholic", NoahActivity_MyOnScrollChangedListener.class, __md_methods);
	}


	public NoahActivity_MyOnScrollChangedListener ()
	{
		super ();
		if (getClass () == NoahActivity_MyOnScrollChangedListener.class) {
			mono.android.TypeManager.Activate ("Codeholic.NoahActivity+MyOnScrollChangedListener, Codeholic", "", this, new java.lang.Object[] {  });
		}
	}

	public NoahActivity_MyOnScrollChangedListener (crc647393a3d6bb91a4eb.NoahActivity p0)
	{
		super ();
		if (getClass () == NoahActivity_MyOnScrollChangedListener.class) {
			mono.android.TypeManager.Activate ("Codeholic.NoahActivity+MyOnScrollChangedListener, Codeholic", "Codeholic.NoahActivity, Codeholic", this, new java.lang.Object[] { p0 });
		}
	}


	public void onScrollChanged ()
	{
		n_onScrollChanged ();
	}

	private native void n_onScrollChanged ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

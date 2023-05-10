<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Sammy
package crc648316b0a9aa8cfd61;


public class BrowserTabActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Identity.Client.BrowserTabActivity, Microsoft.Identity.Client", BrowserTabActivity.class, __md_methods);
	}


	public BrowserTabActivity ()
	{
		super ();
		if (getClass () == BrowserTabActivity.class) {
			mono.android.TypeManager.Activate ("Microsoft.Identity.Client.BrowserTabActivity, Microsoft.Identity.Client", "", this, new java.lang.Object[] {  });
		}
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
<<<<<<< HEAD
=======
package crc648316b0a9aa8cfd61;


public class BrowserTabActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Microsoft.Identity.Client.BrowserTabActivity, Microsoft.Identity.Client", BrowserTabActivity.class, __md_methods);
	}


	public BrowserTabActivity ()
	{
		super ();
		if (getClass () == BrowserTabActivity.class) {
			mono.android.TypeManager.Activate ("Microsoft.Identity.Client.BrowserTabActivity, Microsoft.Identity.Client", "", this, new java.lang.Object[] {  });
		}
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
>>>>>>> 0ab5a17... plugin manager and plugin uploader both functional (pull data from DB and populate fields, update DB when fields are changed). added DatabaseConnection.cs for sending SQL queries.
=======
>>>>>>> Sammy

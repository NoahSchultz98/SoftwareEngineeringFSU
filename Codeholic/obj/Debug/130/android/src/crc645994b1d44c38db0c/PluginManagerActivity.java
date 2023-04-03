package crc645994b1d44c38db0c;


public class PluginManagerActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Codeholic.Resources.PluginManagerActivity, Codeholic", PluginManagerActivity.class, __md_methods);
	}


	public PluginManagerActivity ()
	{
		super ();
		if (getClass () == PluginManagerActivity.class) {
			mono.android.TypeManager.Activate ("Codeholic.Resources.PluginManagerActivity, Codeholic", "", this, new java.lang.Object[] {  });
		}
	}

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

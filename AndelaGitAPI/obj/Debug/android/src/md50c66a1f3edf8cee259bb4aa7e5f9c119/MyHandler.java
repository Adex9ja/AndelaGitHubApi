package md50c66a1f3edf8cee259bb4aa7e5f9c119;


public class MyHandler
	extends android.os.Handler
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_dispatchMessage:(Landroid/os/Message;)V:GetDispatchMessage_Landroid_os_Message_Handler\n" +
			"";
		mono.android.Runtime.register ("AndelaGitAPI.MyHandler, AndelaGitAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyHandler.class, __md_methods);
	}


	public MyHandler () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyHandler.class)
			mono.android.TypeManager.Activate ("AndelaGitAPI.MyHandler, AndelaGitAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public MyHandler (android.os.Handler.Callback p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == MyHandler.class)
			mono.android.TypeManager.Activate ("AndelaGitAPI.MyHandler, AndelaGitAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.OS.Handler+ICallback, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public MyHandler (android.os.Looper p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == MyHandler.class)
			mono.android.TypeManager.Activate ("AndelaGitAPI.MyHandler, AndelaGitAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.OS.Looper, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public MyHandler (android.os.Looper p0, android.os.Handler.Callback p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == MyHandler.class)
			mono.android.TypeManager.Activate ("AndelaGitAPI.MyHandler, AndelaGitAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.OS.Looper, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.OS.Handler+ICallback, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}

	public MyHandler (android.content.Context p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == MyHandler.class)
			mono.android.TypeManager.Activate ("AndelaGitAPI.MyHandler, AndelaGitAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public void dispatchMessage (android.os.Message p0)
	{
		n_dispatchMessage (p0);
	}

	private native void n_dispatchMessage (android.os.Message p0);

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

using System;
using UnityEngine;

namespace StartApp
{
	public class StartAppWrapper : MonoBehaviour
	{
		public interface AdEventListener
		{
			void onReceiveAd();

			void onFailedToReceiveAd();
		}

		public interface AdDisplayListener
		{
			void adHidden();

			void adDisplayed();

			void adClicked();
		}

		public interface VideoListener
		{
			void onVideoCompleted();
		}

		public enum AdMode
		{
			AUTOMATIC = 1,
			FULLPAGE,
			OFFERWALL,
			REWARDED_VIDEO,
			[Obsolete]
			OVERLAY
		}

		public class SplashConfig
		{
			public enum Theme
			{
				DEEP_BLUE = 1,
				SKY,
				ASHEN_SKY,
				BLAZE,
				GLOOMY,
				OCEAN
			}

			public enum Orientation
			{
				PORTRAIT = 1,
				LANDSCAPE,
				AUTO
			}

			private AndroidJavaObject javaSplashConfig;

			public SplashConfig()
			{
				init();
				javaSplashConfig = new AndroidJavaObject("com.startapp.android.publish.splash.SplashConfig");
			}

			public AndroidJavaObject getJavaSplashConfig()
			{
				return javaSplashConfig;
			}

			public SplashConfig setAppName(string appName)
			{
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.lang.String", appName);
				wrapper.Call<AndroidJavaObject>("setAppName", new object[2]
				{
					getJavaSplashConfig(),
					androidJavaObject
				});
				return this;
			}

			public SplashConfig setTheme(Theme theme)
			{
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.lang.Integer", (int)theme);
				wrapper.Call<AndroidJavaObject>("setTheme", new object[2]
				{
					getJavaSplashConfig(),
					androidJavaObject
				});
				return this;
			}

			public SplashConfig setLogo(string fileName)
			{
				byte[] array = null;
				Texture2D texture2D = Resources.Load(fileName) as Texture2D;
				if (texture2D != null)
				{
					array = texture2D.EncodeToJPG();
				}
				wrapper.Call<AndroidJavaObject>("setLogo", new object[2]
				{
					getJavaSplashConfig(),
					array
				});
				return this;
			}

			public SplashConfig setOrientation(Orientation orientation)
			{
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.lang.Integer", (int)orientation);
				wrapper.Call<AndroidJavaObject>("setOrientation", new object[2]
				{
					getJavaSplashConfig(),
					androidJavaObject
				});
				return this;
			}
		}

		private class ImplementationAdEventListener : AndroidJavaProxy
		{
			private AdEventListener listener;

			public ImplementationAdEventListener(AdEventListener listener)
				: base("com.startapp.android.publish.AdEventListener")
			{
				this.listener = listener;
			}

			private void onReceiveAd(AndroidJavaObject ad)
			{
				if (listener != null)
				{
					listener.onReceiveAd();
				}
			}

			private void onFailedToReceiveAd(AndroidJavaObject ad)
			{
				if (listener != null)
				{
					listener.onFailedToReceiveAd();
				}
			}

			private int hashCode()
			{
				return listener.GetHashCode();
			}

			private bool equals(AndroidJavaObject o)
			{
				int num = o.Call<int>("hashCode", new object[0]);
				return num == listener.GetHashCode();
			}
		}

		private class ImplementationAdDisplayListener : AndroidJavaProxy
		{
			private AdDisplayListener listener;

			public ImplementationAdDisplayListener(AdDisplayListener listener)
				: base("com.startapp.android.publish.AdDisplayListener")
			{
				this.listener = listener;
			}

			private void adHidden(AndroidJavaObject ad)
			{
				if (listener != null)
				{
					listener.adHidden();
				}
			}

			private void adDisplayed(AndroidJavaObject ad)
			{
				if (listener != null)
				{
					listener.adDisplayed();
				}
			}

			private void adClicked(AndroidJavaObject ad)
			{
				if (listener != null)
				{
					listener.adClicked();
				}
			}

			private int hashCode()
			{
				return listener.GetHashCode();
			}

			private bool equals(AndroidJavaObject o)
			{
				int num = o.Call<int>("hashCode", new object[0]);
				return num == listener.GetHashCode();
			}
		}

		private class OnBackPressedAdDisplayListener : AndroidJavaProxy
		{
			private string gameObjectName;

			private bool clicked;

			public OnBackPressedAdDisplayListener(string gameObjectName)
				: base("com.startapp.android.publish.AdDisplayListener")
			{
				this.gameObjectName = gameObjectName;
			}

			private void adHidden(AndroidJavaObject ad)
			{
				if (!clicked)
				{
					init();
					Application.Quit();
				}
			}

			private void adDisplayed(AndroidJavaObject ad)
			{
			}

			private void adClicked(AndroidJavaObject ad)
			{
				clicked = true;
			}

			private void adNotDisplayed(AndroidJavaObject ad)
			{
			}
		}

		private class ImplementationVideoListener : AndroidJavaProxy
		{
			private VideoListener listener;

			public ImplementationVideoListener(VideoListener listener)
				: base("com.startapp.android.publish.video.VideoListener")
			{
				this.listener = listener;
			}

			private void onVideoCompleted()
			{
				if (listener != null)
				{
					listener.onVideoCompleted();
				}
			}
		}

		public enum BannerPosition
		{
			BOTTOM,
			TOP
		}

		public enum BannerType
		{
			AUTOMATIC,
			STANDARD,
			THREED
		}

		private static string accountId;

		private static string applicationId;

		private static bool enableReturnAds = true;

		private static bool isAccountIdUsed;

		private static AndroidJavaClass unityClass;

		private static AndroidJavaObject currentActivity;

		private static AndroidJavaObject wrapper;

		public static void setVideoListener(VideoListener listener)
		{
			init();
			wrapper.Call("setVideoListener", new ImplementationVideoListener(listener));
		}

		public static void loadAd(AdEventListener listener)
		{
			loadAd(AdMode.AUTOMATIC, listener);
		}

		public static void loadAd(AdMode adMode)
		{
			loadAd(adMode, null);
		}

		public static void loadAd(AdMode adMode, AdEventListener listener)
		{
			loadAd(adMode, listener, false);
		}

		private static void loadAd(AdMode adMode, AdEventListener listener, bool is3D)
		{
			init();
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.lang.Integer", (int)adMode);
			AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("java.lang.Boolean", is3D);
			if (listener == null)
			{
				wrapper.Call("loadAd", androidJavaObject);
			}
			else
			{
				wrapper.Call("loadAd", androidJavaObject, new ImplementationAdEventListener(listener));
			}
		}

		public static bool showAd(AdDisplayListener listener)
		{
			init();
			return wrapper.Call<bool>("showAd", new object[1]
			{
				new ImplementationAdDisplayListener(listener)
			});
		}

		public static bool onBackPressed(string gameObjectName)
		{
			init();
			return wrapper.Call<bool>("onBackPressed", new object[1]
			{
				new OnBackPressedAdDisplayListener(gameObjectName)
			});
		}

		public static void showSplash()
		{
			init();
			wrapper.Call("showSplash");
		}

		public static void showSplash(SplashConfig splashConfig)
		{
			init();
			wrapper.Call("showSplash", splashConfig.getJavaSplashConfig());
		}

		public static void loadAd()
		{
			init();
			wrapper.Call("loadAd");
		}

		public static bool showAd()
		{
			init();
			return wrapper.Call<bool>("showAd", new object[0]);
		}

		public static void addBanner()
		{
			addBanner(BannerType.AUTOMATIC, BannerPosition.BOTTOM);
		}

		public static void addBanner(BannerType bannerType, BannerPosition position)
		{
			int num = 1;
			int num2 = 1;
			switch (position)
			{
			case BannerPosition.BOTTOM:
				num = 1;
				break;
			case BannerPosition.TOP:
				num = 2;
				break;
			}
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.lang.Integer", num);
			switch (bannerType)
			{
			case BannerType.AUTOMATIC:
				num2 = 1;
				break;
			case BannerType.STANDARD:
				num2 = 2;
				break;
			case BannerType.THREED:
				num2 = 3;
				break;
			}
			AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("java.lang.Integer", num2);
			init();
			wrapper.Call("addBanner", androidJavaObject2, androidJavaObject);
		}

		public static void removeBanner()
		{
			removeBanner(BannerPosition.BOTTOM);
		}

		public static void removeBanner(BannerPosition position)
		{
			int num = 1;
			switch (position)
			{
			case BannerPosition.BOTTOM:
				num = 1;
				break;
			case BannerPosition.TOP:
				num = 2;
				break;
			}
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.lang.Integer", num);
			init();
			wrapper.Call("removeBanner", androidJavaObject);
		}

		public static void disableReturnAds()
		{
			enableReturnAds = false;
		}

		public static void init()
		{
			if (wrapper == null)
			{
				initWrapper();
			}
		}

		private static void initWrapper()
		{
			//AndroidJavaObject androidJavaObject = null;
			//AndroidJavaObject androidJavaObject2 = null;
			//AndroidJavaObject androidJavaObject3 = null;
//			unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			//currentActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
//			wrapper = new AndroidJavaObject("com.startapp.android.unity.InAppWrapper", currentActivity);
			if (!initUserData())
			{
				//throw new ArgumentException("Error in initializing Application ID, Account ID or Return Ads. Please verify your StartAppData.txt file.");
			}
			//androidJavaObject = new AndroidJavaObject("java.lang.String", applicationId);
			//androidJavaObject3 = new AndroidJavaObject("java.lang.Boolean", enableReturnAds);
			if (isAccountIdUsed)
			{
				//androidJavaObject2 = new AndroidJavaObject("java.lang.String", accountId);
				//wrapper.Call("init", androidJavaObject2, androidJavaObject, androidJavaObject3);
			}
			else
			{
				//wrapper.Call("init", androidJavaObject, androidJavaObject3);
			}
		}

		private static bool initUserData()
		{
			bool result = false;
			int num = 0;
			TextAsset textAsset = (TextAsset)Resources.Load("StartAppData");
			string text = textAsset.ToString();
			string[] array = text.Split('\n');
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split('=');
				if (array2[0].ToLower().CompareTo("applicationid") == 0)
				{
					num++;
					applicationId = array2[1].ToString().Trim();
				}
				if (array2[0].ToLower().CompareTo("accountid") == 0 || array2[0].ToLower().CompareTo("developerid") == 0)
				{
					isAccountIdUsed = true;
					accountId = array2[1].ToString().Trim();
				}
				if (array2[0].ToLower().CompareTo("returnads") == 0 && array2[1].ToLower().Equals("false"))
				{
					num++;
					disableReturnAds();
				}
			}
			removeSpecialCharacters();
			if ((enableReturnAds && num == 1) || (!enableReturnAds && num == 2))
			{
				Debug.Log("Initialization successful");
				Debug.Log("Application ID: " + applicationId);
				if (isAccountIdUsed)
				{
					Debug.Log("Account ID: " + accountId);
				}
				if (enableReturnAds)
				{
					Debug.Log("Return ads are enabled");
				}
				result = true;
			}
			return result;
		}

		private static void removeSpecialCharacters()
		{
			if (applicationId != null && applicationId.IndexOf("\"") != -1)
			{
				applicationId = applicationId.Replace("\"", string.Empty);
			}
			if (isAccountIdUsed && accountId != null && accountId.IndexOf("\"") != -1)
			{
				accountId = accountId.Replace("\"", string.Empty);
			}
		}
	}
}

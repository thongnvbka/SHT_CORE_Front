using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;

namespace WebAppBasite.Common.WebLibs
{
    namespace WebLibs
    {
        [Serializable]
        public class HttpRequest : IDisposable
        {
            public delegate void EventReceivedDataHandler(long size);

            public delegate void EventGetDataHandler(char[] buffer);

            private string _ErrCode = "";

            private string _CurrentURL = "";

            private string _UserAgent = "";

            private string _Referer = "";

            private string _ContentType = "application/x-www-form-urlencoded";

            private string _TranferEncode = "gzip, deflate";

            public int _Timeout;

            private CookieCollection cookies = new CookieCollection();

            [method: CompilerGenerated]
            //[DebuggerBrowsable(DebuggerBrowsableState.Never), CompilerGenerated]
           // [System.AttributeUsage(System.AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
            public event HttpRequest.EventReceivedDataHandler OnReceivedDataInfo;

            [method: CompilerGenerated]
           // [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public event HttpRequest.EventReceivedDataHandler OnWritedFileTracing;

            [method: CompilerGenerated]
           //  [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public event HttpRequest.EventGetDataHandler OnGetData;

            public string ErrorCode
            {
                get
                {
                    return this._ErrCode;
                }
            }

            public string CurrentURL
            {
                get
                {
                    return this._CurrentURL;
                }
            }

            public string UserAgent
            {
                get
                {
                    return this._UserAgent;
                }
                set
                {
                    this._UserAgent = value;
                }
            }

            public string Referer
            {
                get
                {
                    return this._Referer;
                }
                set
                {
                    this._Referer = value;
                }
            }

            public string ContentType
            {
                get
                {
                    return this._ContentType;
                }
                set
                {
                    this._ContentType = value;
                }
            }

            public string TranferEncode
            {
                get
                {
                    return this._TranferEncode;
                }
                set
                {
                    this._TranferEncode = value;
                }
            }

            public CookieCollection Cookies
            {
                get
                {
                    return this.cookies;
                }
            }

            public string MethodCustom
            {
                get;
                set;
            }

            public HttpRequest()
            {
                this._UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:13.0) Gecko/20100101 Firefox/13.0";
            }

            public HttpRequest(int usrAgent)
            {
                switch (usrAgent)
                {
                    case 0:
                        this._UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.1) Gecko/20060111 Firefox/1.5.0.1";
                        break;
                    case 1:
                        this._UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.8.1.14) Gecko/20080404 Firefox/2.0.0.14";
                        break;
                    case 2:
                        this._UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.30; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                        break;
                    case 3:
                        this._UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36";
                        break;
                }
            }

            public void Dispose()
            {
            }

            public static string GetHttpPrefix(string strCurURL)
            {
                bool flag = strCurURL == null || strCurURL == "";
                string result;
                if (flag)
                {
                    result = null;
                }
                else
                {
                    int num = strCurURL.IndexOf("//");
                    bool flag2 = num < 0;
                    if (flag2)
                    {
                        result = null;
                    }
                    else
                    {
                        result = strCurURL.Substring(0, num);
                    }
                }
                return result;
            }

            public static string GetCurrentFolder(string strURL)
            {
                string result;
                try
                {
                    Uri uri = new Uri(strURL);
                    string text = HttpRequest.GetHttpPrefix(strURL);
                    bool flag = text == null;
                    if (flag)
                    {
                        text = "http:";
                    }
                    string text2 = string.Format("{0}//{1}", text, uri.Host);
                    ArrayList arrayList = new ArrayList();
                    string[] segments = uri.Segments;
                    for (int i = 0; i < segments.Length; i++)
                    {
                        string value = segments[i];
                        arrayList.Add(value);
                    }
                    string text3 = (string)arrayList[arrayList.Count - 1];
                    bool flag2 = text3.IndexOf(".") >= 0 && arrayList.Count > 1;
                    if (flag2)
                    {
                        arrayList.RemoveAt(arrayList.Count - 1);
                    }
                    for (int j = 0; j < arrayList.Count; j++)
                    {
                        text2 += (string)arrayList[j];
                    }
                    bool flag3 = text2.EndsWith("/");
                    if (flag3)
                    {
                        text2 = text2.Substring(0, text2.Length - 1);
                    }
                    arrayList.Clear();
                    result = text2;
                }
                catch
                {
                    result = null;
                }
                return result;
            }

            public static string GetParentFolder(string strURL)
            {
                string result;
                try
                {
                    Uri uri = new Uri(strURL);
                    string text = HttpRequest.GetHttpPrefix(strURL);
                    bool flag = text == null;
                    if (flag)
                    {
                        text = "http:";
                    }
                    string text2 = string.Format("{0}//{1}", text, uri.Host);
                    ArrayList arrayList = new ArrayList();
                    string[] segments = uri.Segments;
                    for (int i = 0; i < segments.Length; i++)
                    {
                        string value = segments[i];
                        arrayList.Add(value);
                    }
                    for (int j = 0; j < arrayList.Count - 1; j++)
                    {
                        text2 += (string)arrayList[j];
                    }
                    bool flag2 = text2.EndsWith("/");
                    if (flag2)
                    {
                        text2 = text2.Substring(0, text2.Length - 1);
                    }
                    arrayList.Clear();
                    result = text2;
                }
                catch (UriFormatException var_12_C4)
                {
                    result = null;
                }
                return result;
            }

            public static string GetRootURL(string strCurrentURL)
            {
                string result;
                try
                {
                    Uri uri = new Uri(strCurrentURL);
                    result = string.Format("{0}//{1}", HttpRequest.GetHttpPrefix(strCurrentURL), uri.Host);
                }
                catch (UriFormatException var_2_22)
                {
                    result = null;
                }
                return result;
            }

            public static string StandardizeURL(string strRawURL, string strCurrentURL, string strBaseURL)
            {
                bool flag = strRawURL == null;
                string result;
                if (flag)
                {
                    result = null;
                }
                else
                {
                    strRawURL = strRawURL.Replace(Environment.NewLine, "");
                    string text = strBaseURL;
                    bool flag2 = text == null;
                    if (flag2)
                    {
                        text = HttpRequest.GetCurrentFolder(strCurrentURL);
                    }
                    strRawURL = strRawURL.Replace("&amp;", "&");
                    strRawURL = strRawURL.Replace("&lt;", "<");
                    strRawURL = strRawURL.Replace("&gt;", ">");
                    strRawURL = strRawURL.Replace("\t", null);
                    strRawURL = strRawURL.Replace("\n", null);
                    strRawURL = strRawURL.Trim();
                    strRawURL = strRawURL.Replace("&#xD;&#xA;", "");
                    string text2 = HttpRequest.GetHttpPrefix(strCurrentURL);
                    bool flag3 = text2 == null;
                    if (flag3)
                    {
                        text2 = "http:";
                    }
                    bool flag4 = strRawURL.StartsWith("//");
                    if (flag4)
                    {
                        strRawURL = text2 + strRawURL;
                    }
                    else
                    {
                        bool flag5 = strRawURL.StartsWith("/");
                        if (flag5)
                        {
                            string text3 = HttpRequest.GetRootURL(strCurrentURL);
                            bool flag6 = text3 == null;
                            if (flag6)
                            {
                                result = null;
                                return result;
                            }
                            bool flag7 = text3.EndsWith("/");
                            if (flag7)
                            {
                                text3 = text3.Substring(0, text3.Length - 1);
                            }
                            strRawURL = text3 + strRawURL;
                        }
                        else
                        {
                            bool flag8 = strRawURL.StartsWith("?");
                            if (flag8)
                            {
                                bool flag9 = strBaseURL != null;
                                if (flag9)
                                {
                                    strRawURL = text + strRawURL;
                                }
                                else
                                {
                                    int num = strCurrentURL.IndexOf("?");
                                    bool flag10 = num > 0;
                                    if (flag10)
                                    {
                                        strRawURL = strCurrentURL.Substring(0, num) + strRawURL;
                                    }
                                    else
                                    {
                                        strRawURL = strCurrentURL + strRawURL;
                                    }
                                }
                            }
                            else
                            {
                                bool flag11 = strRawURL.StartsWith("javascript:") || strRawURL.StartsWith("vbscipt:");
                                if (flag11)
                                {
                                    int num2 = strRawURL.IndexOf("'");
                                    bool flag12 = num2 < 0;
                                    if (flag12)
                                    {
                                        result = null;
                                        return result;
                                    }
                                    int num3 = strRawURL.IndexOf("'", num2 + 1);
                                    bool flag13 = num3 <= num2;
                                    if (flag13)
                                    {
                                        result = null;
                                        return result;
                                    }
                                    strRawURL = strRawURL.Substring(num2 + 1, num3 - num2 - 1);
                                    strRawURL = HttpRequest.StandardizeURL(strRawURL, strCurrentURL, text);
                                }
                                else
                                {
                                    bool flag14 = strRawURL.StartsWith("../");
                                    if (flag14)
                                    {
                                        string text4 = text;
                                        while (strRawURL.StartsWith("../"))
                                        {
                                            text4 = HttpRequest.GetParentFolder(text4);
                                            strRawURL = strRawURL.Substring(3);
                                        }
                                        strRawURL = string.Format("{0}/{1}", text4, strRawURL);
                                    }
                                }
                            }
                        }
                    }
                    bool flag15 = strRawURL.StartsWith("./");
                    if (flag15)
                    {
                        string arg = text;
                        while (strRawURL.StartsWith("./"))
                        {
                            strRawURL = strRawURL.Substring(2);
                        }
                        strRawURL = string.Format("{0}/{1}", arg, strRawURL);
                    }
                    else
                    {
                        bool flag16 = !strRawURL.StartsWith("http:") && !strRawURL.StartsWith("https:");
                        if (flag16)
                        {
                            bool flag17 = text.EndsWith("/");
                            if (flag17)
                            {
                                strRawURL = text + strRawURL;
                            }
                            else
                            {
                                strRawURL = string.Format("{0}/{1}", text, strRawURL);
                            }
                        }
                        else
                        {
                            bool flag18 = strRawURL.StartsWith("&");
                            if (flag18)
                            {
                            }
                        }
                    }
                    result = strRawURL;
                }
                return result;
            }

            public string Post(string strPost, string strUrl, ProxyInfo clsProxy)
            {
                return this.Post(strPost, strUrl, clsProxy, 0, -1, true, null, null, "");
            }

            private string start_post(string strPage, string strBuffer)
            {
                byte[] bytes = Encoding.ASCII.GetBytes(strBuffer);
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(strPage);
                bool flag = this.MethodCustom == null || this.MethodCustom == "";
                if (flag)
                {
                    httpWebRequest.Method = "POST";
                }
                else
                {
                    httpWebRequest.Method = this.MethodCustom;
                }
                httpWebRequest.ContentType = "multipart/form-data";
                httpWebRequest.ContentLength = (long)bytes.Length;
                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Console.WriteLine(httpWebResponse.StatusCode);
                Console.WriteLine(httpWebResponse.Server);
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                this.MethodCustom = "";
                return streamReader.ReadToEnd();
            }

            public string Post(string strPost, string strUrl, ProxyInfo clsProxy = null, int start = 0, int end = -1, bool setContentType = true, Hashtable h_args = null, Hashtable c_args = null, string domain = "")
            {
                string result;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(strUrl);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "POST";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    httpWebRequest.AllowAutoRedirect = true;
                    httpWebRequest.KeepAlive = true;
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.Referer = this._Referer;
                    bool flag2 = h_args != null;
                    if (flag2)
                    {
                        foreach (string text in h_args.Keys)
                        {
                            httpWebRequest.Headers[text] = HttpUtility.UrlEncode(h_args[text].ToString());
                        }
                    }
                    CookieContainer cookieContainer = new CookieContainer();
                    bool flag3 = c_args != null;
                    if (flag3)
                    {
                        foreach (string text2 in c_args.Keys)
                        {
                            this.cookies.Add(new Cookie(text2, HttpUtility.UrlEncode(c_args[text2].ToString()), "", domain));
                        }
                    }
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    if (setContentType)
                    {
                        bool flag4 = this.ContentType == "" || this.ContentType == null;
                        if (flag4)
                        {
                            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                        }
                        else
                        {
                            httpWebRequest.ContentType = this._ContentType;
                        }
                    }
                    bool flag5 = clsProxy != null;
                    if (flag5)
                    {
                        bool flag6 = !clsProxy.Server.StartsWith("http");
                        string address;
                        if (flag6)
                        {
                            address = string.Format("http://{0}:{1}", clsProxy.Server, clsProxy.Port);
                        }
                        else
                        {
                            address = "";
                        }
                        WebProxy webProxy = new WebProxy(address, true);
                        bool flag7 = clsProxy.Username.Length > 0;
                        if (flag7)
                        {
                            webProxy.Credentials = new NetworkCredential(clsProxy.Username, clsProxy.Password);
                        }
                        httpWebRequest.Proxy = webProxy;
                    }
                    bool flag8 = strPost.Length > 0;
                    if (flag8)
                    {
                        httpWebRequest.ContentLength = (long)strPost.Length;
                        byte[] bytes = Encoding.ASCII.GetBytes(strPost);
                        httpWebRequest.ContentLength = (long)bytes.Length;
                        Stream requestStream = httpWebRequest.GetRequestStream();
                        requestStream.Write(bytes, 0, bytes.Length);
                        requestStream.Close();
                    }
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    WebHeaderCollection headers = httpWebResponse.Headers;
                    bool flag9 = headers["Location"] != null;
                    if (flag9)
                    {
                        string text3 = HttpRequest.StandardizeURL(headers["Location"], strUrl, null);
                        this._CurrentURL = text3;
                        HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(text3);
                        httpWebRequest2.UserAgent = this._UserAgent;
                        bool flag10 = this.MethodCustom == null || this.MethodCustom == "";
                        if (flag10)
                        {
                            httpWebRequest2.Method = "GET";
                        }
                        else
                        {
                            httpWebRequest2.Method = this.MethodCustom;
                        }
                        httpWebRequest2.AllowAutoRedirect = false;
                        httpWebRequest2.KeepAlive = true;
                        httpWebRequest2.ContentType = "application/x-www-form-urlencoded";
                        cookieContainer.Add(httpWebResponse.Cookies);
                        httpWebRequest2.CookieContainer = cookieContainer;
                        httpWebResponse = (HttpWebResponse)httpWebRequest2.GetResponse();
                        httpWebResponse.Cookies = httpWebRequest2.CookieContainer.GetCookies(httpWebRequest2.RequestUri);
                        this.cookies.Add(httpWebResponse.Cookies);
                    }
                    Encoding encoding = Encoding.GetEncoding("UTF-8");
                    StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), encoding, true);
                    bool flag11 = end == -1;
                    string text4;
                    if (flag11)
                    {
                        text4 = streamReader.ReadToEnd();
                    }
                    else
                    {
                        char[] array = new char[end];
                        streamReader.ReadBlock(array, 0, end);
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(array);
                        text4 = stringBuilder.ToString();
                    }
                    httpWebResponse.Close();
                    streamReader.Close();
                    this.MethodCustom = "";
                    result = text4;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                    result = null;
                }
                return result;
            }

            public bool PostQuick(string strPost, string strUrl, ProxyInfo clsProxy = null)
            {
                bool result;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(strUrl);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "POST";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    httpWebRequest.AllowAutoRedirect = true;
                    httpWebRequest.KeepAlive = true;
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.Referer = this._Referer;
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    bool flag2 = clsProxy != null;
                    if (flag2)
                    {
                        bool flag3 = !clsProxy.Server.StartsWith("http");
                        string address;
                        if (flag3)
                        {
                            address = string.Format("http://{0}:{1}", clsProxy.Server, clsProxy.Port);
                        }
                        else
                        {
                            address = "";
                        }
                        WebProxy webProxy = new WebProxy(address, true);
                        bool flag4 = clsProxy.Username.Length > 0;
                        if (flag4)
                        {
                            webProxy.Credentials = new NetworkCredential(clsProxy.Username, clsProxy.Password);
                        }
                        httpWebRequest.Proxy = webProxy;
                    }
                    bool flag5 = strPost.Length > 0;
                    if (flag5)
                    {
                        httpWebRequest.ContentLength = (long)strPost.Length;
                        byte[] bytes = Encoding.ASCII.GetBytes(strPost);
                        Stream requestStream = httpWebRequest.GetRequestStream();
                        requestStream.Write(bytes, 0, bytes.Length);
                        requestStream.Close();
                    }
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    this.MethodCustom = "";
                    result = true;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                    result = false;
                }
                return result;
            }

            public string Get(string url, string encoding = "", ProxyInfo clsProxy = null, bool setContentType = true, Hashtable h_args = null, Hashtable c_args = null, string domain = "")
            {
                string result;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    if (setContentType)
                    {
                        httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    }
                    CookieContainer cookieContainer = new CookieContainer();
                    bool flag2 = c_args != null;
                    if (flag2)
                    {
                        foreach (string text in c_args.Keys)
                        {
                            this.cookies.Add(new Cookie(text, c_args[text].ToString(), "", domain));
                        }
                    }
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.KeepAlive = true;
                    bool flag3 = h_args != null;
                    if (flag3)
                    {
                        foreach (string text2 in h_args.Keys)
                        {
                            httpWebRequest.Headers[text2] = h_args[text2].ToString();
                        }
                    }
                    bool flag4 = clsProxy != null;
                    if (flag4)
                    {
                        bool flag5 = !clsProxy.Server.StartsWith("http");
                        string address;
                        if (flag5)
                        {
                            address = string.Format("http://{0}:{1}", clsProxy.Server, clsProxy.Port);
                        }
                        else
                        {
                            address = "";
                        }
                        WebProxy webProxy = new WebProxy(address, true);
                        bool flag6 = clsProxy.Username.Length > 0;
                        if (flag6)
                        {
                            webProxy.Credentials = new NetworkCredential(clsProxy.Username, clsProxy.Password);
                        }
                        httpWebRequest.Proxy = webProxy;
                    }
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    bool flag7 = encoding == "";
                    if (flag7)
                    {
                        encoding = "UTF-8";
                    }
                    Encoding encoding2 = Encoding.GetEncoding(encoding);
                    StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), encoding2, true);
                    string text3 = streamReader.ReadToEnd();
                    httpWebResponse.Close();
                    streamReader.Close();
                    this.MethodCustom = "";
                    result = text3;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                    result = "";
                }
                return result;
            }

            public string Get(string url, string encoding, int start, int end, ProxyInfo clsProxy = null)
            {
                string result;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    httpWebRequest.Referer = this._Referer;
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Accept = "*/*";
                    bool flag2 = clsProxy != null;
                    if (flag2)
                    {
                        bool flag3 = !clsProxy.Server.StartsWith("http");
                        string address;
                        if (flag3)
                        {
                            address = string.Format("http://{0}:{1}", clsProxy.Server, clsProxy.Port);
                        }
                        else
                        {
                            address = "";
                        }
                        WebProxy webProxy = new WebProxy(address, true);
                        bool flag4 = clsProxy.Username.Length > 0;
                        if (flag4)
                        {
                            webProxy.Credentials = new NetworkCredential(clsProxy.Username, clsProxy.Password);
                        }
                        httpWebRequest.Proxy = webProxy;
                    }
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    bool flag5 = encoding == "";
                    if (flag5)
                    {
                        encoding = "UTF-8";
                    }
                    Encoding encoding2 = Encoding.GetEncoding(encoding);
                    string text;
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), encoding2, true))
                    {
                        char[] array = new char[end];
                        streamReader.ReadBlock(array, start, end);
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(array);
                        text = stringBuilder.ToString();
                        httpWebResponse.Close();
                        streamReader.Close();
                    }
                    this.MethodCustom = "";
                    result = text;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                    result = "";
                }
                return result;
            }

            public bool GetResponseCookie(string url, ProxyInfo clsProxy = null)
            {
                bool result;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    httpWebRequest.Referer = this._Referer;
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Accept = "*/*";
                    bool flag2 = this._Timeout > 0;
                    if (flag2)
                    {
                        httpWebRequest.Timeout = this._Timeout;
                    }
                    bool flag3 = clsProxy != null;
                    if (flag3)
                    {
                        bool flag4 = !clsProxy.Server.StartsWith("http");
                        string address;
                        if (flag4)
                        {
                            address = string.Format("http://{0}:{1}", clsProxy.Server, clsProxy.Port);
                        }
                        else
                        {
                            address = "";
                        }
                        WebProxy webProxy = new WebProxy(address, true);
                        bool flag5 = clsProxy.Username.Length > 0;
                        if (flag5)
                        {
                            webProxy.Credentials = new NetworkCredential(clsProxy.Username, clsProxy.Password);
                        }
                        httpWebRequest.Proxy = webProxy;
                    }
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    Encoding encoding = Encoding.GetEncoding("UTF-8");
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), encoding, true))
                    {
                        httpWebResponse.Close();
                        streamReader.Close();
                    }
                    this.MethodCustom = "";
                    result = true;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                    result = false;
                }
                return result;
            }

            public string GetRedirectLink(string strUrl, ProxyInfo clsProxy = null)
            {
                string result;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(strUrl);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.Referer = this._Referer;
                    bool flag2 = clsProxy != null;
                    if (flag2)
                    {
                        bool flag3 = !clsProxy.Server.StartsWith("http");
                        string address;
                        if (flag3)
                        {
                            address = string.Format("http://{0}:{1}", clsProxy.Server, clsProxy.Port);
                        }
                        else
                        {
                            address = "";
                        }
                        WebProxy webProxy = new WebProxy(address, true);
                        bool flag4 = clsProxy.Username.Length > 0;
                        if (flag4)
                        {
                            webProxy.Credentials = new NetworkCredential(clsProxy.Username, clsProxy.Password);
                        }
                        httpWebRequest.Proxy = webProxy;
                    }
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    this._CurrentURL = httpWebResponse.ResponseUri.AbsoluteUri;
                    WebHeaderCollection headers = httpWebResponse.Headers;
                    bool flag5 = headers["Location"] != null;
                    if (flag5)
                    {
                        string text = HttpRequest.StandardizeURL(headers["Location"], strUrl, null);
                        this._CurrentURL = text;
                        HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(text);
                        httpWebRequest2.UserAgent = this._UserAgent;
                        bool flag6 = this.MethodCustom == null || this.MethodCustom == "";
                        if (flag6)
                        {
                            httpWebRequest2.Method = "GET";
                        }
                        else
                        {
                            httpWebRequest2.Method = this.MethodCustom;
                        }
                        httpWebRequest2.AllowAutoRedirect = false;
                        httpWebRequest2.KeepAlive = true;
                        httpWebRequest2.ContentType = "application/x-www-form-urlencoded";
                        cookieContainer.Add(httpWebResponse.Cookies);
                        httpWebRequest2.CookieContainer = cookieContainer;
                        httpWebResponse = (HttpWebResponse)httpWebRequest2.GetResponse();
                        httpWebResponse.Cookies = httpWebRequest2.CookieContainer.GetCookies(httpWebRequest2.RequestUri);
                        this.cookies.Add(httpWebResponse.Cookies);
                    }
                    this.MethodCustom = "";
                    result = this._CurrentURL;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                    result = "";
                }
                return result;
            }

            public string GetRedirectLink_FromWMP(string strUrl, ProxyInfo clsProxy = null)
            {
                string result;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(strUrl);
                    httpWebRequest.UserAgent = "Windows-Media-Player/11.0.6000.6344";
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    httpWebRequest.ContentType = "audio/x-ms-asx";
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.KeepAlive = true;
                    httpWebRequest.Referer = this._Referer;
                    bool flag2 = clsProxy != null;
                    if (flag2)
                    {
                        bool flag3 = !clsProxy.Server.StartsWith("http");
                        string address;
                        if (flag3)
                        {
                            address = string.Format("http://{0}:{1}", clsProxy.Server, clsProxy.Port);
                        }
                        else
                        {
                            address = "";
                        }
                        WebProxy webProxy = new WebProxy(address, true);
                        bool flag4 = clsProxy.Username.Length > 0;
                        if (flag4)
                        {
                            webProxy.Credentials = new NetworkCredential(clsProxy.Username, clsProxy.Password);
                        }
                        httpWebRequest.Proxy = webProxy;
                    }
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    this._CurrentURL = httpWebResponse.ResponseUri.AbsoluteUri;
                    WebHeaderCollection headers = httpWebResponse.Headers;
                    bool flag5 = headers["Location"] != null;
                    if (flag5)
                    {
                        string text = HttpRequest.StandardizeURL(headers["Location"], strUrl, null);
                        this._CurrentURL = text;
                        HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(text);
                        httpWebRequest2.UserAgent = this._UserAgent;
                        bool flag6 = this.MethodCustom == null || this.MethodCustom == "";
                        if (flag6)
                        {
                            httpWebRequest2.Method = "GET";
                        }
                        else
                        {
                            httpWebRequest2.Method = this.MethodCustom;
                        }
                        httpWebRequest2.AllowAutoRedirect = false;
                        httpWebRequest2.KeepAlive = true;
                        httpWebRequest2.ContentType = "application/x-www-form-urlencoded";
                        cookieContainer.Add(httpWebResponse.Cookies);
                        httpWebRequest2.CookieContainer = cookieContainer;
                        httpWebResponse = (HttpWebResponse)httpWebRequest2.GetResponse();
                        httpWebResponse.Cookies = httpWebRequest2.CookieContainer.GetCookies(httpWebRequest2.RequestUri);
                        this.cookies.Add(httpWebResponse.Cookies);
                    }
                    this.MethodCustom = "";
                    result = this._CurrentURL;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                    result = "";
                }
                return result;
            }

            public byte[] DownloadFileFull(string url)
            {
                byte[] result;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Accept = "*/*";
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    this._CurrentURL = httpWebResponse.ResponseUri.AbsoluteUri;
                    Encoding @default = Encoding.Default;
                    StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), @default, true);
                    byte[] bytes = @default.GetBytes(streamReader.ReadToEnd());
                    httpWebResponse.Close();
                    streamReader.Close();
                    this.MethodCustom = "";
                    result = bytes;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                    result = null;
                }
                return result;
            }

            public void DownloadFileFullWithEvent_GetData(string url)
            {
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Accept = "*/*";
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    this._CurrentURL = httpWebResponse.ResponseUri.AbsoluteUri;
                    Encoding @default = Encoding.Default;
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), @default, true))
                    {
                        long contentLength = httpWebResponse.ContentLength;
                        bool flag2 = this.OnReceivedDataInfo != null;
                        if (flag2)
                        {
                            this.OnReceivedDataInfo(contentLength);
                        }
                        char[] buffer = new char[1024];
                        while (!streamReader.EndOfStream)
                        {
                            streamReader.ReadBlock(buffer, 0, 1024);
                            this.OnGetData(buffer);
                        }
                        httpWebResponse.Close();
                        streamReader.Close();
                    }
                    this.MethodCustom = "";
                }
                catch (Exception ex)
                {
                    this.MethodCustom = "";
                    this._ErrCode = ex.Message;
                }
            }

            public long DownloadFile(string url, ProxyInfo clsProxy, out StreamReader responseStream, out HttpWebResponse response)
            {
                response = null;
                responseStream = null;
                long result;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Accept = "*/*";
                    bool flag2 = clsProxy != null;
                    if (flag2)
                    {
                        bool flag3 = !clsProxy.Server.StartsWith("http");
                        string address;
                        if (flag3)
                        {
                            address = string.Format("http://{0}:{1}", clsProxy.Server, clsProxy.Port);
                        }
                        else
                        {
                            address = "";
                        }
                        WebProxy webProxy = new WebProxy(address, true);
                        bool flag4 = clsProxy.Username.Length > 0;
                        if (flag4)
                        {
                            webProxy.Credentials = new NetworkCredential(clsProxy.Username, clsProxy.Password);
                        }
                        httpWebRequest.Proxy = webProxy;
                    }
                    response = (HttpWebResponse)httpWebRequest.GetResponse();
                    response.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(response.Cookies);
                    this._CurrentURL = response.ResponseUri.AbsoluteUri;
                    Encoding @default = Encoding.Default;
                    responseStream = new StreamReader(response.GetResponseStream(), @default, true);
                    this.MethodCustom = "";
                    result = response.ContentLength;
                    return result;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                }
                result = 0L;
                return result;
            }

            public long DownloadFileFullToDisk(string url, string PathName, bool setContentType = true, Hashtable h_args = null, Hashtable c_args = null, string domain = "")
            {
                long num = 0L;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    if (setContentType)
                    {
                        httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    }
                    CookieContainer cookieContainer = new CookieContainer();
                    bool flag2 = c_args != null;
                    if (flag2)
                    {
                        foreach (string text in c_args.Keys)
                        {
                            this.cookies.Add(new Cookie(text, c_args[text].ToString(), "", domain));
                        }
                    }
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.KeepAlive = true;
                    bool flag3 = h_args != null;
                    if (flag3)
                    {
                        foreach (string text2 in h_args.Keys)
                        {
                            httpWebRequest.Headers[text2] = h_args[text2].ToString();
                        }
                    }
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    this._CurrentURL = httpWebResponse.ResponseUri.AbsoluteUri;
                    Encoding @default = Encoding.Default;
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), @default, true))
                    {
                        num = httpWebResponse.ContentLength;
                        bool flag4 = this.OnReceivedDataInfo != null;
                        if (flag4)
                        {
                            this.OnReceivedDataInfo(num);
                        }
                        FileStream fileStream = new FileStream(PathName, FileMode.Create, FileAccess.ReadWrite);
                        try
                        {
                            long num2 = 0L;
                            int num3 = 16384;
                            char[] array = new char[num3];
                            while (!streamReader.EndOfStream)
                            {
                                num2 += (long)num3;
                                bool flag5 = num2 > num;
                                int num4;
                                if (flag5)
                                {
                                    num4 = (int)((long)num3 - (num2 - num));
                                    array = new char[num4];
                                }
                                else
                                {
                                    num4 = num3;
                                }
                                streamReader.ReadBlock(array, 0, num4);
                                StringBuilder stringBuilder = new StringBuilder();
                                stringBuilder.Append(array);
                                Encoding default2 = Encoding.Default;
                                byte[] bytes = default2.GetBytes(stringBuilder.ToString());
                                fileStream.Write(bytes, 0, bytes.Length);
                            }
                        }
                        catch (Exception ex)
                        {
                            num = 0L;
                            throw new Exception(string.Format("Error downloading and writing to disk: {0} - {1}{2}{3}", new object[]
                            {
                            url,
                            PathName,
                            Environment.NewLine,
                            ex.Message
                            }));
                        }
                        finally
                        {
                            httpWebResponse.Close();
                            streamReader.Close();
                            fileStream.Close();
                            fileStream.Dispose();
                            this.MethodCustom = "";
                        }
                    }
                }
                catch (Exception ex2)
                {
                    this._ErrCode = ex2.Message;
                    this.MethodCustom = "";
                }
                return num;
            }

            public string DownloadFileFullToDisk2(string url, string PathName, ProxyInfo clsProxy = null)
            {
                string text = "";
                string result;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    bool flag = this.Referer != "";
                    if (flag)
                    {
                        httpWebRequest.Referer = this.Referer;
                    }
                    httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36";
                    bool flag2 = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag2)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Accept = "*/*";
                    httpWebRequest.Headers["Upgrade-Insecure-Requests"] = "1";
                    httpWebRequest.Headers["Accept-Encoding"] = "gzip, deflate, sdch";
                    httpWebRequest.Headers["Accept-Language"] = "en-US,en;q=0.8";
                    bool flag3 = clsProxy != null;
                    if (flag3)
                    {
                        bool flag4 = !clsProxy.Server.StartsWith("http");
                        string address;
                        if (flag4)
                        {
                            address = string.Format("http://{0}:{1}", clsProxy.Server, clsProxy.Port);
                        }
                        else
                        {
                            address = "";
                        }
                        WebProxy webProxy = new WebProxy(address, true);
                        bool flag5 = clsProxy.Username.Length > 0;
                        if (flag5)
                        {
                            webProxy.Credentials = new NetworkCredential(clsProxy.Username, clsProxy.Password);
                        }
                        httpWebRequest.Proxy = webProxy;
                    }
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    bool flag6 = text == "";
                    if (flag6)
                    {
                        text = "UTF-8";
                    }
                    Encoding encoding = Encoding.GetEncoding(text);
                    StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), encoding, true);
                    string text2 = streamReader.ReadToEnd();
                    byte[] bytes = encoding.GetBytes(text2);
                    FileStream fileStream = new FileStream(PathName, FileMode.Create, FileAccess.ReadWrite);
                    fileStream.Write(bytes, 0, bytes.Length);
                    httpWebResponse.Close();
                    streamReader.Close();
                    this.MethodCustom = "";
                    result = text2;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                    result = "";
                }
                return result;
            }

            public long DownloadFileFullToDiskWithEventNofity(string url, string PathName)
            {
                long num = 0L;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Accept = "*/*";
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    this._CurrentURL = httpWebResponse.ResponseUri.AbsoluteUri;
                    Encoding @default = Encoding.Default;
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), @default, true))
                    {
                        num = httpWebResponse.ContentLength;
                        bool flag2 = this.OnReceivedDataInfo != null;
                        if (flag2)
                        {
                            this.OnReceivedDataInfo(num);
                        }
                        FileStream fileStream = new FileStream(PathName, FileMode.Create, FileAccess.ReadWrite);
                        try
                        {
                            long num2 = 0L;
                            int num3 = 16384;
                            char[] array = new char[num3];
                            while (!streamReader.EndOfStream)
                            {
                                num2 += (long)num3;
                                bool flag3 = num2 > num;
                                int num4;
                                if (flag3)
                                {
                                    num4 = (int)((long)num3 - (num2 - num));
                                    array = new char[num4];
                                }
                                else
                                {
                                    num4 = num3;
                                }
                                streamReader.ReadBlock(array, 0, num4);
                                StringBuilder stringBuilder = new StringBuilder();
                                stringBuilder.Append(array);
                                Encoding default2 = Encoding.Default;
                                byte[] bytes = default2.GetBytes(stringBuilder.ToString());
                                fileStream.Write(bytes, 0, bytes.Length);
                                this.OnWritedFileTracing(num2);
                            }
                        }
                        catch (Exception ex)
                        {
                            num = 0L;
                            throw new Exception(string.Format("Error downloading and writing to disk: {0} - {1}{2}{3}", new object[]
                            {
                            url,
                            PathName,
                            Environment.NewLine,
                            ex.Message
                            }));
                        }
                        finally
                        {
                            httpWebResponse.Close();
                            streamReader.Close();
                            fileStream.Close();
                            fileStream.Dispose();
                            this.MethodCustom = "";
                        }
                    }
                }
                catch (Exception ex2)
                {
                    this._ErrCode = ex2.Message;
                    this.MethodCustom = "";
                }
                return num;
            }

            public long GetFileHeader(string url, out HttpWebResponse response, ProxyInfo clsProxy = null)
            {
                long result;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Referer = this._Referer;
                    httpWebRequest.Accept = "*/*";
                    bool flag2 = clsProxy != null;
                    if (flag2)
                    {
                        bool flag3 = !clsProxy.Server.StartsWith("http");
                        string address;
                        if (flag3)
                        {
                            address = string.Format("http://{0}:{1}", clsProxy.Server, clsProxy.Port);
                        }
                        else
                        {
                            address = "";
                        }
                        WebProxy webProxy = new WebProxy(address, true);
                        bool flag4 = clsProxy.Username.Length > 0;
                        if (flag4)
                        {
                            webProxy.Credentials = new NetworkCredential(clsProxy.Username, clsProxy.Password);
                        }
                        httpWebRequest.Proxy = webProxy;
                    }
                    response = (HttpWebResponse)httpWebRequest.GetResponse();
                    response.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(response.Cookies);
                    this._CurrentURL = response.ResponseUri.AbsoluteUri;
                    long contentLength = response.ContentLength;
                    response.Close();
                    this.MethodCustom = "";
                    result = contentLength;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    response = null;
                    this.MethodCustom = "";
                    result = 0L;
                }
                return result;
            }

            public byte[] DownloadFileFullWithEvent_ReceivedDataInfo(string url)
            {
                byte[] result;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Accept = "*/*";
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    this._CurrentURL = httpWebResponse.ResponseUri.AbsoluteUri;
                    Encoding @default = Encoding.Default;
                    StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), @default, true);
                    string text = "";
                    char[] array = new char[1024];
                    int num = 0;
                    while (!streamReader.EndOfStream)
                    {
                        streamReader.ReadBlock(array, 0, 1024);
                        char[] array2 = array;
                        for (int i = 0; i < array2.Length; i++)
                        {
                            char c = array2[i];
                            text += c.ToString();
                        }
                        this.OnReceivedDataInfo((long)num);
                        num++;
                    }
                    byte[] bytes = @default.GetBytes(text);
                    httpWebResponse.Close();
                    streamReader.Close();
                    streamReader.Dispose();
                    this.MethodCustom = "";
                    result = bytes;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                    result = null;
                }
                return result;
            }

            public Image DownloadImage(string urlFile)
            {
                Image result;
                try
                {
                    bool flag = urlFile.Length == 0;
                    if (flag)
                    {
                        result = null;
                    }
                    else
                    {
                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(urlFile);
                        httpWebRequest.UserAgent = this._UserAgent;
                        httpWebRequest.AllowAutoRedirect = false;
                        httpWebRequest.KeepAlive = true;
                        bool flag2 = this.MethodCustom == null || this.MethodCustom == "";
                        if (flag2)
                        {
                            httpWebRequest.Method = "GET";
                        }
                        else
                        {
                            httpWebRequest.Method = this.MethodCustom;
                        }
                        CookieContainer cookieContainer = new CookieContainer();
                        cookieContainer.Add(this.cookies);
                        httpWebRequest.CookieContainer = cookieContainer;
                        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        Stream responseStream = httpWebResponse.GetResponseStream();
                        StreamReader streamReader = new StreamReader(responseStream);
                        Image image = Image.FromStream(responseStream);
                        responseStream.Close();
                        streamReader.Close();
                        httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                        this.cookies.Add(httpWebResponse.Cookies);
                        httpWebResponse.Close();
                        this.MethodCustom = "";
                        result = image;
                    }
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                    result = null;
                }
                return result;
            }

            public static byte[] DownloadFile(string urlFile)
            {
                byte[] result;
                try
                {
                    WebClient webClient = new WebClient();
                    byte[] array = webClient.DownloadData(urlFile);
                    result = array;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    result = null;
                }
                return result;
            }

            public byte[] DownloadFile(string url, int start, int end)
            {
                byte[] result;
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag)
                    {
                        httpWebRequest.Method = "GET";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.Accept = "*/*";
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    this._CurrentURL = httpWebResponse.ResponseUri.AbsoluteUri;
                    Encoding @default = Encoding.Default;
                    StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), @default, true);
                    char[] array = new char[end];
                    streamReader.ReadBlock(array, start, end);
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(array);
                    byte[] bytes = @default.GetBytes(stringBuilder.ToString());
                    httpWebResponse.Close();
                    streamReader.Close();
                    streamReader.Dispose();
                    this.MethodCustom = "";
                    result = bytes;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                    result = null;
                }
                return result;
            }

            public string UploadFile(byte[] data, string fileName, string postUrl, string postHeader, string postFooter, string contentType, string boundary)
            {
                string result;
                try
                {
                    bool flag = !postUrl.Contains("http:") && !postUrl.Contains("https:");
                    if (flag)
                    {
                        postUrl = "http://" + postUrl;
                    }
                    this._CurrentURL = postUrl;
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(postUrl);
                    httpWebRequest.UserAgent = this._UserAgent;
                    bool flag2 = this.MethodCustom == null || this.MethodCustom == "";
                    if (flag2)
                    {
                        httpWebRequest.Method = "POST";
                    }
                    else
                    {
                        httpWebRequest.Method = this.MethodCustom;
                    }
                    httpWebRequest.AllowAutoRedirect = true;
                    httpWebRequest.KeepAlive = true;
                    httpWebRequest.Accept = "*/*";
                    CookieContainer cookieContainer = new CookieContainer();
                    cookieContainer.Add(this.cookies);
                    httpWebRequest.CookieContainer = cookieContainer;
                    httpWebRequest.ContentType = contentType;
                    byte[] bytes = Encoding.ASCII.GetBytes(postHeader);
                    byte[] bytes2 = Encoding.ASCII.GetBytes(postFooter);
                    httpWebRequest.ContentLength = (long)(bytes.Length + data.Length + bytes2.Length);
                    Stream requestStream = httpWebRequest.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Write(bytes2, 0, bytes2.Length);
                    requestStream.Close();
                    HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    httpWebResponse.Cookies = httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri);
                    this.cookies.Add(httpWebResponse.Cookies);
                    Encoding encoding = Encoding.GetEncoding("UTF-8");
                    StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), encoding, true);
                    string text = streamReader.ReadToEnd();
                    httpWebResponse.Close();
                    streamReader.Close();
                    this.MethodCustom = "";
                    result = text;
                }
                catch (Exception ex)
                {
                    this._ErrCode = ex.Message;
                    this.MethodCustom = "";
                    result = null;
                }
                return result;
            }
        }
    }
}

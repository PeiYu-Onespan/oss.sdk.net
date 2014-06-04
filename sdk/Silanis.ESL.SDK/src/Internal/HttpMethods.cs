using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace Silanis.ESL.SDK.Internal
{
	/// <summary>
	/// For internal use.
	/// </summary>
	public class HttpMethods
	{
		public static byte[] PostHttp (string apiToken, string path, byte[] content)
		{
			Support.LogMethodEntry(apiToken, path, content);
            try {
				WebRequest request = WebRequest.Create (path);
				request.Method = "POST";
				request.ContentType = "application/json";
				request.ContentLength = content.Length;
				request.Headers.Add ("Authorization", "Basic " + apiToken);

				using (Stream dataStream = request.GetRequestStream ()) {
					dataStream.Write (content, 0, content.Length);
				}

				Support.LogDebug( "Awaiting response from server." );
				WebResponse response = request.GetResponse ();
				Support.LogDebug( "Response received from server. " + response.ToString() + "," + response.Headers.ToString() + "," + response.ContentType + "," + response.ContentLength + " bytes." );

				using (Stream responseStream = response.GetResponseStream()) {
					var memoryStream = new MemoryStream ();
					CopyTo (responseStream, memoryStream);
	          
					byte[] result = memoryStream.ToArray();
					Support.LogMethodExit( result );      
					return result;
				}
            }
            catch (Exception e) {
				Support.LogError(e.Message);
				Support.LogError(e.StackTrace);
                throw new EslException("Error communicating with esl server. " + e.Message, e);
            }
		}

		public static byte[] PutHttp (string apiToken, string path, byte[] content)
		{
			Support.LogMethodEntry(apiToken, path, content);
			try {
				WebRequest request = WebRequest.Create (path);
				request.Method = "PUT";
				request.ContentType = "application/json";
				request.ContentLength = content.Length;
				request.Headers.Add ("Authorization", "Basic " + apiToken);

				using (Stream dataStream = request.GetRequestStream ()) {
					dataStream.Write (content, 0, content.Length);
				}

				Support.LogDebug( "Awaiting response from server." );
				WebResponse response = request.GetResponse ();
				Support.LogDebug( "Response received from server. " + response.ToString() + "," + response.Headers.ToString() + "," + response.ContentType + "," + response.ContentLength + " bytes." );

				using (Stream responseStream = response.GetResponseStream()) {
					var memoryStream = new MemoryStream ();
					CopyTo (responseStream, memoryStream);

					byte[] result = memoryStream.ToArray();
					Support.LogMethodExit(result);
					return result;
				}
			}
			catch (Exception e) {
				Support.LogError(e.Message);
				Support.LogError(e.StackTrace);
				throw new EslException("Error communicating with esl server. " + e.Message,e);
			}
		}

        /// <summary>
        /// Can only be called for unauthenticated path such as /auth
        /// Gets the http.
        /// </summary>
        public static byte[] GetHttp (string path)
        {
            Support.LogMethodEntry(path);
            try {
                WebRequest request = WebRequest.Create (path);
                request.Method = "GET";

                Support.LogDebug( "Awaiting response from server." );
                WebResponse response = request.GetResponse ();
                Support.LogDebug( "Response received from server. " + response.ToString() + "," + response.Headers.ToString() + "," + response.ContentType + "," + response.ContentLength + " bytes." );

                using (Stream responseStream = response.GetResponseStream()) {
                    var memoryStream = new MemoryStream ();
                    CopyTo (responseStream, memoryStream);
                    byte[] result = memoryStream.ToArray();
                    Support.LogMethodExit(result);
                    return result;
                }
            }
            catch (Exception e) {
                Support.LogError(e.Message);
                Support.LogError(e.StackTrace);
                throw new EslException("Error communicating with esl server. " + e.Message,e);
            }
        }

		public static byte[] GetHttpJson (string apiToken, string path)
		{
			Support.LogMethodEntry(apiToken, path);
			try {
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create (path);
				request.Method = "GET";
				request.Headers.Add ("Authorization", "Basic " + apiToken);
				request.Accept = "application/json";

				Support.LogDebug( "Awaiting response from server." );
				WebResponse response = request.GetResponse ();
				Support.LogDebug( "Response received from server. " + response.ToString() + "," + response.Headers.ToString() + "," + response.ContentType + "," + response.ContentLength + " bytes." );

				using (Stream responseStream = response.GetResponseStream()) {
					var memoryStream = new MemoryStream ();
					CopyTo (responseStream, memoryStream);
					byte[] result = memoryStream.ToArray();
					Support.LogMethodExit(result);
					return result;
				}
			}
			catch (Exception e) {
				Support.LogError(e.Message);
				Support.LogError(e.StackTrace);
				throw new EslException("Error communicating with esl server. " + e.Message,e);
			}
		}

		public static byte[] GetHttp (string apiToken, string path)
		{
			Support.LogMethodEntry(apiToken, path);
			try {
				WebRequest request = WebRequest.Create (path);
				request.Method = "GET";
				request.Headers.Add ("Authorization", "Basic " + apiToken);

				Support.LogDebug( "Awaiting response from server." );
				WebResponse response = request.GetResponse ();
				Support.LogDebug( "Response received from server. " + response.ToString() + "," + response.Headers.ToString() + "," + response.ContentType + "," + response.ContentLength + " bytes." );

				using (Stream responseStream = response.GetResponseStream()) {
					var memoryStream = new MemoryStream ();
					CopyTo (responseStream, memoryStream);
					byte[] result = memoryStream.ToArray();
					Support.LogMethodExit(result);
					return result;
				}
			}
			catch (Exception e) {
				Support.LogError(e.Message);
				Support.LogError(e.StackTrace);
				throw new EslException("Error communicating with esl server. " + e.Message,e);
			}
		}

		public static byte[] DeleteHttp (string apiToken, string path)
		{
			Support.LogMethodEntry(apiToken, path);
			try {
				WebRequest request = WebRequest.Create (path);
				request.Method = "DELETE";
				request.Headers.Add ("Authorization", "Basic " + apiToken);

				Support.LogDebug( "Awaiting response from server." );
				WebResponse response = request.GetResponse ();
				Support.LogDebug( "Response received from server. " + response.ToString() + "," + response.Headers.ToString() + "," + response.ContentType + "," + response.ContentLength + " bytes." );

				using (Stream responseStream = response.GetResponseStream()) {
					var memoryStream = new MemoryStream ();
					CopyTo (responseStream, memoryStream);
					byte[] result = memoryStream.ToArray();
					Support.LogMethodExit(result);
					return result;
				}
			}
			catch (Exception e) {
				Support.LogError(e.Message);
				Support.LogError(e.StackTrace);
				throw new EslException("Error communicating with esl server. " + e.Message,e);
			}
		}

		public static void AddAuthorizationHeader(WebRequest request, AuthHeaderGenerator authHeaderGen)
		{
			request.Headers.Add(authHeaderGen.Name, authHeaderGen.Value);
		}

		public static byte[] MultipartPostHttp (string apiToken, string path, byte[] content, string boundary, AuthHeaderGenerator authHeaderGen)
		{
			Support.LogMethodEntry(apiToken, path, content, boundary);
			WebRequest request = WebRequest.Create (path);
			try {
				request.Method = "POST";
				request.ContentType = string.Format ("multipart/form-data; boundary={0}", boundary);
				request.ContentLength = content.Length;
				AddAuthorizationHeader(request, authHeaderGen);

				using (Stream dataStream = request.GetRequestStream ()) {
					dataStream.Write (content, 0, content.Length);
				}

				Support.LogDebug( "Awaiting response from server." );
				WebResponse response = request.GetResponse ();
				Support.LogDebug( "Response received from server. " + response.ToString() + "," + response.Headers.ToString() + "," + response.ContentType + "," + response.ContentLength + " bytes." );

				using (Stream responseStream = response.GetResponseStream()) {
					var memoryStream = new MemoryStream ();
					CopyTo (responseStream, memoryStream);
					byte[] result = memoryStream.ToArray();
					Support.LogMethodExit(result);
					return result;
				}
			}
			catch (Exception e) {
				Support.LogError(e.Message);
				Support.LogError(e.StackTrace);
				throw new EslException("Error communicating with esl server. " + e.Message,e);
			}
		}

		private static void CopyTo (Stream input, Stream output)
		{
			byte[] buffer = new byte[16 * 1024]; // Fairly arbitrary size
			int bytesRead;

			while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0) {
				output.Write (buffer, 0, bytesRead);
			}
		}

	}
}


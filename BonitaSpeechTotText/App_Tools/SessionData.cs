using BonitaSpeechTotText.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BonitaSpeechTotText.App_Tools
{
    public class SessionData
    {
        public static ApplicationUser userData;
        private static SessionManager Session = new SessionManager();
        /// <summary>
        /// Gets a value indicating whether [session in].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [session in]; otherwise, <c>false</c>.
        /// </value>
        public static bool SessionOut => HttpContext.Current == null;
        public static string UserId
        {
            get
            {
                try
                {
                    string id = Session.GetValue<string>("Session.UserId");
                    if (string.IsNullOrEmpty(id))
                    {
                        id = HttpContext.Current.User.Identity.GetUserId();
                        Session.SetValue("Session.UserId", id);
                    }
                    return id;
                }
                catch (Exception ex)
                {

                }

                return null;
            }
        }
        public static bool isRecepcionsita
        {
            get
            {
                try
                {

                    if (UserId != null)
                    {
                        bool resultado = false;
                        using (var context = new ApplicationDbContext())
                        {
                            var blogNames = context.Database.SqlQuery<bool>("SELECT isRecepcionista FROM AspNetUsers WHERE Id = @Id", new System.Data.SqlClient.SqlParameter("@Id", UserId)).ToList();
                            foreach (var item in blogNames)
                            {
                                resultado = item;
                            }
                        }
                        if (resultado)
                        {

                            return true;

                        }
                        return false;


                    }

                }
                catch (Exception ex)
                {

                }

                return false;
            }
        }
        public static bool isSupterminal
        {
            get
            {
                try
                {                    
                    if (UserId != null)
                    {
                        bool resultado = false;
                        using (var context = new ApplicationDbContext())
                        {
                            var blogNames = context.Database.SqlQuery<bool>("SELECT IsSupterminal FROM AspNetUsers WHERE Id = @Id", new System.Data.SqlClient.SqlParameter("@Id", UserId)).ToList();
                            foreach (var item in blogNames)
                            {
                                resultado = item;
                            }
                        }

                        if (resultado)
                        {

                            return true;

                        }
                        return false;

                       
                    }
               
                }
                catch (Exception ex)
                {

                }

                return false;
            }
        }
        public static bool isSupbodega
        {
            get
            {
                try
                {                  
                    if (UserId != null)
                    {
                        bool resultado = false;
                        using (var context = new ApplicationDbContext())
                        {
                            var blogNames = context.Database.SqlQuery<bool>("SELECT IsSupbodega FROM AspNetUsers WHERE Id = @Id", new System.Data.SqlClient.SqlParameter("@Id", UserId)).ToList();
                            foreach (var item in blogNames)
                            {
                                resultado = item;
                            }
                        }

                        if (resultado)
                        {

                            return true;

                        }
                        return false;
                     
                    }
                  
                }
                catch (Exception ex)
                {

                }

                return false;
            }
        }
        public static bool isAuxdian
        {
            get
            {
                try
                {
               
                    if (UserId != null)
                    {
                        bool resultado = false;
                        using (var context = new ApplicationDbContext())
                        {
                            var blogNames = context.Database.SqlQuery<bool>("SELECT IsAuxdian FROM AspNetUsers WHERE Id = @Id", new System.Data.SqlClient.SqlParameter("@Id", UserId)).ToList();
                            foreach (var item in blogNames)
                            {
                                resultado = item;
                            }
                        }

                        if (resultado)
                        {

                            return true;

                        }
                        return false;

                  
                    }
                   
                }
                catch (Exception ex)
                {

                }

                return false;
            }
        }
        public static bool isDigitalizador
        {
            get
            {
                try
                {
                  
                    if (UserId != null)
                    {
                        bool resultado = false;
                        using (var context = new ApplicationDbContext())
                        {
                            var blogNames = context.Database.SqlQuery<bool>("SELECT IsDigitador FROM AspNetUsers WHERE Id = @Id", new System.Data.SqlClient.SqlParameter("@Id", UserId)).ToList();
                            foreach (var item in blogNames)
                            {
                                resultado = item;
                            }
                        }

                        if (resultado)
                        {

                            return true;

                        }
                        return false;
                    }
               
                }
                catch (Exception ex)
                {

                }

                return false;
            }
        }



        public class SessionManager
        {
            public static ApplicationUser userData;
            #region Methods
            /// <summary>
            /// Adds the value to persistense variables.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <param name="value">The value.</param>
            public void SetValue(string key, object value)
            {
                if (HttpContext.Current != null)
                {
                    System.Web.SessionState.HttpSessionState session = HttpContext.Current.Session;
                    session[key] = value;
                }
            }
            /// <summary>
            /// Gets the resource.
            /// </summary>
            /// <typeparam name="T">Data type of return.</typeparam>
            /// <param name="key">The key.</param>
            /// <returns>Returns if it [value not equals null] the value of param otherwise default value </returns>
            public T GetValue<T>(string key)
            {
                if (HttpContext.Current != null)
                {
                    System.Web.SessionState.HttpSessionState session = HttpContext.Current.Session;
                    return session[key] == null ? default(T) : (T)Convert.ChangeType(session[key], typeof(T));
                }

                return default(T);
            }
            /// <summary>
            /// Clears this instance.
            /// </summary>
            public void Clear()
            {
                System.Web.SessionState.HttpSessionState session = HttpContext.Current.Session;
                session.Clear();
                session.Abandon();
            }
            #endregion
        }

    }
}
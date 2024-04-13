using System;

namespace GameSystemSDK.Common.Domain
{
    /// <summary>
    /// Simple Result Interface(Bool Type)
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Is Success
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// エラー発生場合、エラーメッセージ
        /// </summary>
        string ErrorMessage { get; }
        string StackTrace { get; }
    }

    /// <summary>
    /// データを埋め込んで結果を返すResult Interface
    /// </summary>
    /// <typeparam name="T">Data Type</typeparam>
    public interface IResult<T> : IResult
    {
        /// <summary>
        /// 成功時返す加工済みのデータ
        /// </summary>
        T Value { get; }
    }

    /// <summary>
    /// データを埋め込んで結果を返すResult 実装部
    /// </summary>
    public static class Result
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <typeparam name="T">Data Type</typeparam>
        /// <param name="value">成功時返す加工済みのデータ</param>
        /// <returns>成功結果</returns>
        public static IResult<T> Success<T>( T value ) => new Impl<T>( value );
        public static IResult<T> Fail<T>( string msg ) => new Impl<T>( msg );

        public static IResult<T> Fail<T>( IResult result )
        {
            if( result.IsSuccess )
            {
                throw new ArgumentException();
            }

            return new Impl<T>( result.ErrorMessage, result.StackTrace );
        }


        /// <summary>
        /// 成功
        /// </summary>
        public static IResult Success() => Impl.Success();

        /// <summary>
        /// 失敗
        /// </summary>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>失敗情報</returns>
        public static IResult Fail( string msg ) => new Impl( msg );

        public static IResult Fail( IResult result )
        {
            if( result.IsSuccess )
            {
                throw new ArgumentException();
            }

            return new Impl( result.ErrorMessage, result.StackTrace );
        }

        /// <summary>
        /// データを埋め込んで結果を返すResult 拡張 Class
        /// </summary>
        public struct Impl<T> : IResult<T>
        {
            /// <summary>
            /// 結果
            /// </summary>
            public bool IsSuccess { get; }

            /// <summary>
            /// エラーメッセージ
            /// </summary>
            public string ErrorMessage { get; }

            public string StackTrace { get; }

            /// <summary>
            /// 加工済みのデータ（成功時）
            /// </summary>
            public T Value { get; }

            /// <summary>
            /// 成功の場合に使われるConstructor
            /// </summary>
            /// <param name="value">加工済みのデータ</param>
            public Impl( T value )
            {
                IsSuccess = true;
                Value = value;
                ErrorMessage = string.Empty;
                StackTrace = string.Empty;
            }

            /// <summary>
            /// 失敗の場合に使われるConstructor
            /// </summary>
            /// <param name="errorMessage">エラーメッセージ</param>
            public Impl( string errorMessage )
            {
                IsSuccess = false;
                Value = default;
                ErrorMessage = errorMessage;
                StackTrace = Environment.StackTrace;
            }

            public Impl( string errorMessage, string stackTrace )
            {
                IsSuccess = false;
                Value = default;
                ErrorMessage = errorMessage;
                StackTrace = stackTrace;
            }
        }

        /// <summary>
        /// Result 拡張
        /// </summary>
        private struct Impl : IResult
        {
            /// <summary>
            /// Is Success
            /// </summary>
            public bool IsSuccess { get; }

            /// <summary>
            /// エラー発生場合、エラーメッセージ
            /// </summary>
            public string ErrorMessage { get; }
            public string StackTrace { get; }

            public static Impl Success()
            {
                return new Impl( true, string.Empty, string.Empty );
            }

            /// <summary>
            /// Constuctor(for Fail)
            /// </summary>
            /// <param name="errorMessage">Error Massage</param>
            public Impl( string errorMessage )
                : this ( false, errorMessage, Environment.StackTrace)
            {
            }

            public Impl( string errorMessage, string stackTrace )
                : this( false, errorMessage, stackTrace )
            {
            }

            private Impl(
                bool IsSuccess,
                string ErrorMessage,
                string StackTrace )
            {
                this.IsSuccess = IsSuccess;
                this.ErrorMessage = ErrorMessage;
                this.StackTrace = StackTrace;
            }
        }
    }
}

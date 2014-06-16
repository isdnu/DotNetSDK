using System;
using System.Collections.Generic;

namespace SDNUMobile.SDK.Utilities
{
    /// <summary>
    /// 键值对比较器
    /// </summary>
    /// <typeparam name="TKey">键类型</typeparam>
    /// <typeparam name="TValue">值类型</typeparam>
    public class KeyValuePairComparer<TKey, TValue> : Comparer<KeyValuePair<TKey, TValue>>
    {
        #region 静态字段
        private static KeyValuePairComparer<TKey, TValue> _default;
        #endregion

        #region 静态属性
        /// <summary>
        /// 获取默认键值对比较器
        /// </summary>
        public new static KeyValuePairComparer<TKey, TValue> Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new KeyValuePairComparer<TKey, TValue>();
                }

                return _default;
            }
        }
        #endregion

        #region 字段
        private IComparer<TKey> _baseComparer;
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的键值对比较器
        /// </summary>
        public KeyValuePairComparer()
        {
            this._baseComparer = Comparer<TKey>.Default;
        }
        #endregion

        #region 方法
        public override Int32 Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
        {
            return this._baseComparer.Compare(x.Key, y.Key);
        }
        #endregion
    }
}
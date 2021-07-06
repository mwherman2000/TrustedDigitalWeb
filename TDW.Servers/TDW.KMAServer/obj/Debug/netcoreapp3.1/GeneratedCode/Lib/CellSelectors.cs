#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
using Trinity.TSL.Lib;
using Trinity.Storage;
using System.Linq.Expressions;
using TDW.KMAServer.Linq;
using Trinity.Storage.Transaction;
namespace TDW.KMAServer
{
    
    #region Internal
    /**
     * <summary>
     * Accepts transformation from KMAKeyPair_Accessor to T.
     * </summary>
     */
    internal class KMAKeyPair_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         KMAKeyPair_Accessor_local_query_provider    query_provider;
        internal KMAKeyPair_Accessor_local_projector(KMAKeyPair_Accessor_local_query_provider provider, Expression expression)
        {
            this.query_expression              = expression;
            this.query_provider                = provider;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<T>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(T); }
        }
        public Expression Expression
        {
            get { return query_expression; }
        }
        public IQueryProvider Provider
        {
            get { return query_provider; }
        }
    }
    /**
     * Accepts transformation from KMAKeyPair to T.
     */
    internal class KMAKeyPair_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         KMAKeyPair_local_query_provider             query_provider;
        internal KMAKeyPair_local_projector(KMAKeyPair_local_query_provider provider, Expression expression)
        {
            this.query_expression              = expression;
            this.query_provider                = provider;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<T>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(T); }
        }
        public Expression Expression
        {
            get { return query_expression; }
        }
        public IQueryProvider Provider
        {
            get { return query_provider; }
        }
    }
    internal class KMAKeyPair_AccessorEnumerable : IEnumerable<KMAKeyPair_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<KMAKeyPair_Accessor,bool> m_filter_predicate;
        internal KMAKeyPair_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.m_storage     = storage;
            m_filter_set       = null;
            m_filter_predicate = null;
            m_tx               = tx;
        }
        internal void SetPositiveFiltering(HashSet<long> set)
        {
            this.m_filter_set       = set;
            m_is_positive_filtering = true;
        }
        internal void SetNegativeFiltering(HashSet<long> set)
        {
            this.m_filter_set       = set;
            m_is_positive_filtering = false;
        }
        public IEnumerator<KMAKeyPair_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.KMAKeyPair)
                        {
                            var accessor = KMAKeyPair_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.KMAKeyPair)
                        {
                            var accessor = KMAKeyPair_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            if (m_filter_predicate(accessor))
                                yield return accessor;
                            accessor.Dispose();
                        }
                    }
            }
            else if (m_is_positive_filtering)
            {
                if (m_filter_predicate == null)
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseKMAKeyPair(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseKMAKeyPair(cellID))
                        {
                            if (m_filter_predicate(accessor))
                                yield return accessor;
                        }
                    }
            }
            else
            {
                throw new NotImplementedException("Negative filtering not supported.");
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        internal void SetPredicate(Expression aggregated_where_clause, ParameterExpression parameter)
        {
            m_filter_predicate = Expression.Lambda<Func<KMAKeyPair_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class KMAKeyPair_Enumerable : IEnumerable<KMAKeyPair>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<KMAKeyPair,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(KMAKeyPair);
        private LocalTransactionContext m_tx;
        internal KMAKeyPair_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_storage          = storage;
            m_filter_set       = null;
            m_filter_predicate = null;
            m_tx               = tx;
        }
        internal void SetPositiveFiltering(HashSet<long> set)
        {
            this.m_filter_set       = set;
            m_is_positive_filtering = true;
        }
        internal void SetNegativeFiltering(HashSet<long> set)
        {
            this.m_filter_set       = set;
            m_is_positive_filtering = false;
        }
        public IEnumerator<KMAKeyPair> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.KMAKeyPair)
                        {
                            var accessor = KMAKeyPair_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.KMAKeyPair)
                        {
                            var accessor = KMAKeyPair_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            if (m_filter_predicate(accessor))
                                yield return accessor;
                            accessor.Dispose();
                        }
                    }
            }
            else if (m_is_positive_filtering)
            {
                if (m_filter_predicate == null)
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseKMAKeyPair(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseKMAKeyPair(cellID))
                        {
                            if (m_filter_predicate(accessor))
                                yield return accessor;
                        }
                    }
            }
            else
            {
                throw new NotImplementedException("Negative filtering not supported.");
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        internal void SetPredicate(Expression aggregated_where_clause, ParameterExpression parameter)
        {
            m_filter_predicate = Expression.Lambda<Func<KMAKeyPair, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class KMAKeyPair_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(KMAKeyPair_Accessor);
        private static  Type                             s_cell_type        = typeof(KMAKeyPair);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         KMAKeyPair_AccessorEnumerable   m_accessor_enumerable;
        internal KMAKeyPair_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new KMAKeyPair_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new KMAKeyPair_Accessor_local_selector(this, expression);
            }
            else
            {
                return new KMAKeyPair_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<KMAKeyPair_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<KMAKeyPair_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(KMAKeyPair_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<KMAKeyPair_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<KMAKeyPair_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<KMAKeyPair_Accessor>("KMAKeyPair", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
                aggregated_predicate                                               = query_tree_gen.Visit(aggregated_predicate);
                var query_tree                                                     = query_tree_gen.QueryTree;
                if (query_tree != null)
                {
                    query_tree = query_tree.Optimize();
                    var query_tree_exec = new IndexQueryTreeExecutor(Index.s_AccessorSubstringQueryMethodTable, Index.s_AccessorSubstringWildcardQueryMethodTable);
                    m_accessor_enumerable.SetPositiveFiltering(query_tree_exec.Execute(query_tree));
                }
                m_accessor_enumerable.SetPredicate(aggregated_predicate, subject_rewriter.Parameter);
            }
            if (trimmed_expression.NodeType == ExpressionType.Constant)
            {
                return (TResult)m_accessor_enumerable.GetEnumerator();
            }
            Type result_type          = typeof(TResult);
            bool result_is_enumerable = (result_type.GenericTypeArguments.Count() == 1);
            Type element_type         = result_is_enumerable ? result_type.GenericTypeArguments[0] : result_type;
            if (result_is_enumerable)
            {
                var  enumerator_type      = s_ienumerable_type.MakeGenericType(element_type);
                var  enumerator_extractor = Expression.Call(trimmed_expression, enumerator_type.GetMethod("GetEnumerator"));
                var  lambda               = Expression.Lambda<Func<TResult>>(enumerator_extractor);
                var  func                 = (lambda).Compile();
                var  result               = func();
                return result;
            }
            else
            {
                var  lambda               = Expression.Lambda<Func<TResult>>(trimmed_expression);
                var  func                 = (lambda).Compile();
                var  result               = func();
                return result;
            }
        }
        #region Not implemented
        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }
        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    internal class KMAKeyPair_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(KMAKeyPair);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         KMAKeyPair_Enumerable           s_cell_enumerable;
        internal KMAKeyPair_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new KMAKeyPair_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new KMAKeyPair_local_selector(this, expression);
            }
            else
            {
                return new KMAKeyPair_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<KMAKeyPair>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<KMAKeyPair>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(KMAKeyPair_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<KMAKeyPair>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<KMAKeyPair> query_tree_gen       = new IndexQueryTreeGenerator<KMAKeyPair>("KMAKeyPair", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
                aggregated_predicate                                      = query_tree_gen.Visit(aggregated_predicate);
                var query_tree                                            = query_tree_gen.QueryTree;
                if (query_tree != null)
                {
                    query_tree = query_tree.Optimize();
                    var query_tree_exec = new IndexQueryTreeExecutor(Index.s_CellSubstringQueryMethodTable, Index.s_CellSubstringWildcardQueryMethodTable);
                    s_cell_enumerable.SetPositiveFiltering(query_tree_exec.Execute(query_tree));
                }
                s_cell_enumerable.SetPredicate(aggregated_predicate, subject_rewriter.Parameter);
            }
            if (trimmed_expression.NodeType == ExpressionType.Constant)
            {
                return (TResult)s_cell_enumerable.GetEnumerator();
            }
            Type result_type          = typeof(TResult);
            bool result_is_enumerable = (result_type.GenericTypeArguments.Count() == 1);
            Type element_type         = result_is_enumerable ? result_type.GenericTypeArguments[0] : result_type;
            if (result_is_enumerable)
            {
                var  enumerator_type      = s_ienumerable_type.MakeGenericType(element_type);
                var  enumerator_extractor = Expression.Call(trimmed_expression, enumerator_type.GetMethod("GetEnumerator"));
                var  lambda               = Expression.Lambda<Func<TResult>>(enumerator_extractor);
                var  func                 = (lambda).Compile();
                var  result               = func();
                return result;
            }
            else
            {
                var  lambda               = Expression.Lambda<Func<TResult>>(trimmed_expression);
                var  func                 = (lambda).Compile();
                var  result               = func();
                return result;
            }
        }
        #region Not implemented
        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }
        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    #endregion
    #region Public
    /// <summary>
    /// Implements System.Linq.IQueryable{KMAKeyPair_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class KMAKeyPair_Accessor_local_selector : IQueryable<KMAKeyPair_Accessor>
    {
        private         Expression                                   query_expression;
        private         KMAKeyPair_Accessor_local_query_provider    query_provider;
        private KMAKeyPair_Accessor_local_selector() { /* nobody should reach this method */ }
        internal KMAKeyPair_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new KMAKeyPair_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe KMAKeyPair_Accessor_local_selector(KMAKeyPair_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<KMAKeyPair_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<KMAKeyPair_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(KMAKeyPair_Accessor); }
        }
        public Expression Expression
        {
            get { return this.query_expression; }
        }
        public IQueryProvider Provider
        {
            get { return query_provider; }
        }
        #endregion
        #region PLINQ Wrapper
        public PLINQWrapper<KMAKeyPair_Accessor> AsParallel()
        {
            return new PLINQWrapper<KMAKeyPair_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{KMAKeyPair} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class KMAKeyPair_local_selector : IQueryable<KMAKeyPair>, IOrderedQueryable<KMAKeyPair>
    {
        private         Expression                                   query_expression;
        private         KMAKeyPair_local_query_provider             query_provider;
        private KMAKeyPair_local_selector() { /* nobody should reach this method */ }
        internal KMAKeyPair_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new KMAKeyPair_local_query_provider(storage, tx);
        }
        internal unsafe KMAKeyPair_local_selector(KMAKeyPair_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<KMAKeyPair> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<KMAKeyPair>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<KMAKeyPair>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(KMAKeyPair); }
        }
        public Expression Expression
        {
            get { return this.query_expression; }
        }
        public IQueryProvider Provider
        {
            get { return query_provider; }
        }
        #endregion
    }
    #endregion
    
    public static class LocalStorageCellSelectorExtension
    {
        
        /// <summary>
        /// Enumerates all the KMAKeyPair within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the KMAKeyPair within the local memory storage.</returns>
        public static KMAKeyPair_local_selector KMAKeyPair_Selector(this LocalMemoryStorage storage)
        {
            return new KMAKeyPair_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the KMAKeyPair_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the KMAKeyPair_Accessor within the local memory storage.</returns>
        public static KMAKeyPair_Accessor_local_selector KMAKeyPair_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new KMAKeyPair_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the KMAKeyPair within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the KMAKeyPair within the local memory storage.</returns>
        public static KMAKeyPair_local_selector KMAKeyPair_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new KMAKeyPair_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the KMAKeyPair_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the KMAKeyPair_Accessor within the local memory storage.</returns>
        public static KMAKeyPair_Accessor_local_selector KMAKeyPair_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new KMAKeyPair_Accessor_local_selector(storage, tx);
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522

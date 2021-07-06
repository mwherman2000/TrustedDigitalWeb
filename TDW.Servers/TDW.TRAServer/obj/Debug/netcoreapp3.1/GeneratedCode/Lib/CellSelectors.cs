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
using TDW.TRAServer.Linq;
using Trinity.Storage.Transaction;
namespace TDW.TRAServer
{
    
    #region Internal
    /**
     * <summary>
     * Accepts transformation from TDWCredential_Accessor to T.
     * </summary>
     */
    internal class TDWCredential_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWCredential_Accessor_local_query_provider    query_provider;
        internal TDWCredential_Accessor_local_projector(TDWCredential_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TDWCredential to T.
     */
    internal class TDWCredential_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWCredential_local_query_provider             query_provider;
        internal TDWCredential_local_projector(TDWCredential_local_query_provider provider, Expression expression)
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
    internal class TDWCredential_AccessorEnumerable : IEnumerable<TDWCredential_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TDWCredential_Accessor,bool> m_filter_predicate;
        internal TDWCredential_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWCredential_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWCredential)
                        {
                            var accessor = TDWCredential_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWCredential)
                        {
                            var accessor = TDWCredential_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWCredential(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWCredential(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWCredential_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWCredential_Enumerable : IEnumerable<TDWCredential>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TDWCredential,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TDWCredential);
        private LocalTransactionContext m_tx;
        internal TDWCredential_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWCredential> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWCredential)
                        {
                            var accessor = TDWCredential_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWCredential)
                        {
                            var accessor = TDWCredential_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWCredential(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWCredential(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWCredential, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWCredential_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TDWCredential_Accessor);
        private static  Type                             s_cell_type        = typeof(TDWCredential);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWCredential_AccessorEnumerable   m_accessor_enumerable;
        internal TDWCredential_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TDWCredential_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TDWCredential_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TDWCredential_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWCredential_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TDWCredential_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWCredential_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWCredential_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWCredential_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TDWCredential_Accessor>("TDWCredential", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TDWCredential_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TDWCredential);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWCredential_Enumerable           s_cell_enumerable;
        internal TDWCredential_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TDWCredential_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TDWCredential_local_selector(this, expression);
            }
            else
            {
                return new TDWCredential_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWCredential>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TDWCredential>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWCredential_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWCredential>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWCredential> query_tree_gen       = new IndexQueryTreeGenerator<TDWCredential>("TDWCredential", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TDWCredential_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWCredential_Accessor_local_selector : IQueryable<TDWCredential_Accessor>
    {
        private         Expression                                   query_expression;
        private         TDWCredential_Accessor_local_query_provider    query_provider;
        private TDWCredential_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TDWCredential_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWCredential_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TDWCredential_Accessor_local_selector(TDWCredential_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TDWCredential_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWCredential_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWCredential_Accessor); }
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
        public PLINQWrapper<TDWCredential_Accessor> AsParallel()
        {
            return new PLINQWrapper<TDWCredential_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TDWCredential} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWCredential_local_selector : IQueryable<TDWCredential>, IOrderedQueryable<TDWCredential>
    {
        private         Expression                                   query_expression;
        private         TDWCredential_local_query_provider             query_provider;
        private TDWCredential_local_selector() { /* nobody should reach this method */ }
        internal TDWCredential_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWCredential_local_query_provider(storage, tx);
        }
        internal unsafe TDWCredential_local_selector(TDWCredential_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TDWCredential> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWCredential>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TDWCredential>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWCredential); }
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
        /// Enumerates all the TDWCredential within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWCredential within the local memory storage.</returns>
        public static TDWCredential_local_selector TDWCredential_Selector(this LocalMemoryStorage storage)
        {
            return new TDWCredential_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWCredential_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWCredential_Accessor within the local memory storage.</returns>
        public static TDWCredential_Accessor_local_selector TDWCredential_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TDWCredential_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWCredential within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWCredential within the local memory storage.</returns>
        public static TDWCredential_local_selector TDWCredential_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWCredential_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TDWCredential_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWCredential_Accessor within the local memory storage.</returns>
        public static TDWCredential_Accessor_local_selector TDWCredential_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWCredential_Accessor_local_selector(storage, tx);
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522

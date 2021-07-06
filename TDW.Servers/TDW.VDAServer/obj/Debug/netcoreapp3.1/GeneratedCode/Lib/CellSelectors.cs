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
using TDW.VDAServer.Linq;
using Trinity.Storage.Transaction;
namespace TDW.VDAServer
{
    
    #region Internal
    /**
     * <summary>
     * Accepts transformation from TDWVDAAccount_Accessor to T.
     * </summary>
     */
    internal class TDWVDAAccount_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWVDAAccount_Accessor_local_query_provider    query_provider;
        internal TDWVDAAccount_Accessor_local_projector(TDWVDAAccount_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TDWVDAAccount to T.
     */
    internal class TDWVDAAccount_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWVDAAccount_local_query_provider             query_provider;
        internal TDWVDAAccount_local_projector(TDWVDAAccount_local_query_provider provider, Expression expression)
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
    internal class TDWVDAAccount_AccessorEnumerable : IEnumerable<TDWVDAAccount_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TDWVDAAccount_Accessor,bool> m_filter_predicate;
        internal TDWVDAAccount_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWVDAAccount_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDAAccount)
                        {
                            var accessor = TDWVDAAccount_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDAAccount)
                        {
                            var accessor = TDWVDAAccount_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWVDAAccount(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWVDAAccount(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWVDAAccount_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWVDAAccount_Enumerable : IEnumerable<TDWVDAAccount>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TDWVDAAccount,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TDWVDAAccount);
        private LocalTransactionContext m_tx;
        internal TDWVDAAccount_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWVDAAccount> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDAAccount)
                        {
                            var accessor = TDWVDAAccount_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDAAccount)
                        {
                            var accessor = TDWVDAAccount_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWVDAAccount(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWVDAAccount(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWVDAAccount, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWVDAAccount_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TDWVDAAccount_Accessor);
        private static  Type                             s_cell_type        = typeof(TDWVDAAccount);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWVDAAccount_AccessorEnumerable   m_accessor_enumerable;
        internal TDWVDAAccount_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TDWVDAAccount_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TDWVDAAccount_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TDWVDAAccount_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWVDAAccount_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TDWVDAAccount_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWVDAAccount_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWVDAAccount_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWVDAAccount_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TDWVDAAccount_Accessor>("TDWVDAAccount", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TDWVDAAccount_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TDWVDAAccount);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWVDAAccount_Enumerable           s_cell_enumerable;
        internal TDWVDAAccount_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TDWVDAAccount_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TDWVDAAccount_local_selector(this, expression);
            }
            else
            {
                return new TDWVDAAccount_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWVDAAccount>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TDWVDAAccount>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWVDAAccount_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWVDAAccount>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWVDAAccount> query_tree_gen       = new IndexQueryTreeGenerator<TDWVDAAccount>("TDWVDAAccount", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TDWVDAAccount_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWVDAAccount_Accessor_local_selector : IQueryable<TDWVDAAccount_Accessor>
    {
        private         Expression                                   query_expression;
        private         TDWVDAAccount_Accessor_local_query_provider    query_provider;
        private TDWVDAAccount_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TDWVDAAccount_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWVDAAccount_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TDWVDAAccount_Accessor_local_selector(TDWVDAAccount_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TDWVDAAccount_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWVDAAccount_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWVDAAccount_Accessor); }
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
        public PLINQWrapper<TDWVDAAccount_Accessor> AsParallel()
        {
            return new PLINQWrapper<TDWVDAAccount_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TDWVDAAccount} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWVDAAccount_local_selector : IQueryable<TDWVDAAccount>, IOrderedQueryable<TDWVDAAccount>
    {
        private         Expression                                   query_expression;
        private         TDWVDAAccount_local_query_provider             query_provider;
        private TDWVDAAccount_local_selector() { /* nobody should reach this method */ }
        internal TDWVDAAccount_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWVDAAccount_local_query_provider(storage, tx);
        }
        internal unsafe TDWVDAAccount_local_selector(TDWVDAAccount_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TDWVDAAccount> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWVDAAccount>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TDWVDAAccount>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWVDAAccount); }
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
    
    #region Internal
    /**
     * <summary>
     * Accepts transformation from TDWVDASmartContract_Accessor to T.
     * </summary>
     */
    internal class TDWVDASmartContract_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWVDASmartContract_Accessor_local_query_provider    query_provider;
        internal TDWVDASmartContract_Accessor_local_projector(TDWVDASmartContract_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TDWVDASmartContract to T.
     */
    internal class TDWVDASmartContract_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWVDASmartContract_local_query_provider             query_provider;
        internal TDWVDASmartContract_local_projector(TDWVDASmartContract_local_query_provider provider, Expression expression)
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
    internal class TDWVDASmartContract_AccessorEnumerable : IEnumerable<TDWVDASmartContract_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TDWVDASmartContract_Accessor,bool> m_filter_predicate;
        internal TDWVDASmartContract_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWVDASmartContract_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDASmartContract)
                        {
                            var accessor = TDWVDASmartContract_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDASmartContract)
                        {
                            var accessor = TDWVDASmartContract_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWVDASmartContract(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWVDASmartContract(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWVDASmartContract_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWVDASmartContract_Enumerable : IEnumerable<TDWVDASmartContract>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TDWVDASmartContract,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TDWVDASmartContract);
        private LocalTransactionContext m_tx;
        internal TDWVDASmartContract_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWVDASmartContract> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDASmartContract)
                        {
                            var accessor = TDWVDASmartContract_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDASmartContract)
                        {
                            var accessor = TDWVDASmartContract_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWVDASmartContract(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWVDASmartContract(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWVDASmartContract, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWVDASmartContract_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TDWVDASmartContract_Accessor);
        private static  Type                             s_cell_type        = typeof(TDWVDASmartContract);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWVDASmartContract_AccessorEnumerable   m_accessor_enumerable;
        internal TDWVDASmartContract_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TDWVDASmartContract_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TDWVDASmartContract_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TDWVDASmartContract_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWVDASmartContract_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TDWVDASmartContract_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWVDASmartContract_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWVDASmartContract_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWVDASmartContract_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TDWVDASmartContract_Accessor>("TDWVDASmartContract", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TDWVDASmartContract_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TDWVDASmartContract);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWVDASmartContract_Enumerable           s_cell_enumerable;
        internal TDWVDASmartContract_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TDWVDASmartContract_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TDWVDASmartContract_local_selector(this, expression);
            }
            else
            {
                return new TDWVDASmartContract_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWVDASmartContract>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TDWVDASmartContract>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWVDASmartContract_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWVDASmartContract>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWVDASmartContract> query_tree_gen       = new IndexQueryTreeGenerator<TDWVDASmartContract>("TDWVDASmartContract", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TDWVDASmartContract_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWVDASmartContract_Accessor_local_selector : IQueryable<TDWVDASmartContract_Accessor>
    {
        private         Expression                                   query_expression;
        private         TDWVDASmartContract_Accessor_local_query_provider    query_provider;
        private TDWVDASmartContract_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TDWVDASmartContract_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWVDASmartContract_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TDWVDASmartContract_Accessor_local_selector(TDWVDASmartContract_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TDWVDASmartContract_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWVDASmartContract_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWVDASmartContract_Accessor); }
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
        public PLINQWrapper<TDWVDASmartContract_Accessor> AsParallel()
        {
            return new PLINQWrapper<TDWVDASmartContract_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TDWVDASmartContract} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWVDASmartContract_local_selector : IQueryable<TDWVDASmartContract>, IOrderedQueryable<TDWVDASmartContract>
    {
        private         Expression                                   query_expression;
        private         TDWVDASmartContract_local_query_provider             query_provider;
        private TDWVDASmartContract_local_selector() { /* nobody should reach this method */ }
        internal TDWVDASmartContract_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWVDASmartContract_local_query_provider(storage, tx);
        }
        internal unsafe TDWVDASmartContract_local_selector(TDWVDASmartContract_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TDWVDASmartContract> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWVDASmartContract>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TDWVDASmartContract>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWVDASmartContract); }
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
        /// Enumerates all the TDWVDAAccount within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDAAccount within the local memory storage.</returns>
        public static TDWVDAAccount_local_selector TDWVDAAccount_Selector(this LocalMemoryStorage storage)
        {
            return new TDWVDAAccount_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWVDAAccount_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDAAccount_Accessor within the local memory storage.</returns>
        public static TDWVDAAccount_Accessor_local_selector TDWVDAAccount_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TDWVDAAccount_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWVDAAccount within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDAAccount within the local memory storage.</returns>
        public static TDWVDAAccount_local_selector TDWVDAAccount_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWVDAAccount_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TDWVDAAccount_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDAAccount_Accessor within the local memory storage.</returns>
        public static TDWVDAAccount_Accessor_local_selector TDWVDAAccount_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWVDAAccount_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the TDWVDASmartContract within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDASmartContract within the local memory storage.</returns>
        public static TDWVDASmartContract_local_selector TDWVDASmartContract_Selector(this LocalMemoryStorage storage)
        {
            return new TDWVDASmartContract_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWVDASmartContract_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDASmartContract_Accessor within the local memory storage.</returns>
        public static TDWVDASmartContract_Accessor_local_selector TDWVDASmartContract_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TDWVDASmartContract_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWVDASmartContract within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDASmartContract within the local memory storage.</returns>
        public static TDWVDASmartContract_local_selector TDWVDASmartContract_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWVDASmartContract_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TDWVDASmartContract_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDASmartContract_Accessor within the local memory storage.</returns>
        public static TDWVDASmartContract_Accessor_local_selector TDWVDASmartContract_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWVDASmartContract_Accessor_local_selector(storage, tx);
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522

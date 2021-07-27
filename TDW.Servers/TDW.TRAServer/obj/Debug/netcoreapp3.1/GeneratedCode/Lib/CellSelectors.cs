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
     * Accepts transformation from TRACredential_Cell_Accessor to T.
     * </summary>
     */
    internal class TRACredential_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TRACredential_Cell_Accessor_local_query_provider    query_provider;
        internal TRACredential_Cell_Accessor_local_projector(TRACredential_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TRACredential_Cell to T.
     */
    internal class TRACredential_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TRACredential_Cell_local_query_provider             query_provider;
        internal TRACredential_Cell_local_projector(TRACredential_Cell_local_query_provider provider, Expression expression)
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
    internal class TRACredential_Cell_AccessorEnumerable : IEnumerable<TRACredential_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TRACredential_Cell_Accessor,bool> m_filter_predicate;
        internal TRACredential_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TRACredential_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRACredential_Cell)
                        {
                            var accessor = TRACredential_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRACredential_Cell)
                        {
                            var accessor = TRACredential_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTRACredential_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTRACredential_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TRACredential_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TRACredential_Cell_Enumerable : IEnumerable<TRACredential_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TRACredential_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TRACredential_Cell);
        private LocalTransactionContext m_tx;
        internal TRACredential_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TRACredential_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRACredential_Cell)
                        {
                            var accessor = TRACredential_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRACredential_Cell)
                        {
                            var accessor = TRACredential_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTRACredential_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTRACredential_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TRACredential_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TRACredential_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TRACredential_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(TRACredential_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TRACredential_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal TRACredential_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TRACredential_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TRACredential_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TRACredential_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TRACredential_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TRACredential_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TRACredential_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TRACredential_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TRACredential_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TRACredential_Cell_Accessor>("TRACredential_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TRACredential_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TRACredential_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TRACredential_Cell_Enumerable           s_cell_enumerable;
        internal TRACredential_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TRACredential_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TRACredential_Cell_local_selector(this, expression);
            }
            else
            {
                return new TRACredential_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TRACredential_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TRACredential_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TRACredential_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TRACredential_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TRACredential_Cell> query_tree_gen       = new IndexQueryTreeGenerator<TRACredential_Cell>("TRACredential_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TRACredential_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TRACredential_Cell_Accessor_local_selector : IQueryable<TRACredential_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         TRACredential_Cell_Accessor_local_query_provider    query_provider;
        private TRACredential_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TRACredential_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TRACredential_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TRACredential_Cell_Accessor_local_selector(TRACredential_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TRACredential_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TRACredential_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TRACredential_Cell_Accessor); }
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
        public PLINQWrapper<TRACredential_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<TRACredential_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TRACredential_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TRACredential_Cell_local_selector : IQueryable<TRACredential_Cell>, IOrderedQueryable<TRACredential_Cell>
    {
        private         Expression                                   query_expression;
        private         TRACredential_Cell_local_query_provider             query_provider;
        private TRACredential_Cell_local_selector() { /* nobody should reach this method */ }
        internal TRACredential_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TRACredential_Cell_local_query_provider(storage, tx);
        }
        internal unsafe TRACredential_Cell_local_selector(TRACredential_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TRACredential_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TRACredential_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TRACredential_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TRACredential_Cell); }
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
     * Accepts transformation from TRATimestamp_Cell_Accessor to T.
     * </summary>
     */
    internal class TRATimestamp_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TRATimestamp_Cell_Accessor_local_query_provider    query_provider;
        internal TRATimestamp_Cell_Accessor_local_projector(TRATimestamp_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TRATimestamp_Cell to T.
     */
    internal class TRATimestamp_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TRATimestamp_Cell_local_query_provider             query_provider;
        internal TRATimestamp_Cell_local_projector(TRATimestamp_Cell_local_query_provider provider, Expression expression)
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
    internal class TRATimestamp_Cell_AccessorEnumerable : IEnumerable<TRATimestamp_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TRATimestamp_Cell_Accessor,bool> m_filter_predicate;
        internal TRATimestamp_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TRATimestamp_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRATimestamp_Cell)
                        {
                            var accessor = TRATimestamp_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRATimestamp_Cell)
                        {
                            var accessor = TRATimestamp_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTRATimestamp_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTRATimestamp_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TRATimestamp_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TRATimestamp_Cell_Enumerable : IEnumerable<TRATimestamp_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TRATimestamp_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TRATimestamp_Cell);
        private LocalTransactionContext m_tx;
        internal TRATimestamp_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TRATimestamp_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRATimestamp_Cell)
                        {
                            var accessor = TRATimestamp_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRATimestamp_Cell)
                        {
                            var accessor = TRATimestamp_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTRATimestamp_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTRATimestamp_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TRATimestamp_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TRATimestamp_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TRATimestamp_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(TRATimestamp_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TRATimestamp_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal TRATimestamp_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TRATimestamp_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TRATimestamp_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TRATimestamp_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TRATimestamp_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TRATimestamp_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TRATimestamp_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TRATimestamp_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TRATimestamp_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TRATimestamp_Cell_Accessor>("TRATimestamp_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TRATimestamp_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TRATimestamp_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TRATimestamp_Cell_Enumerable           s_cell_enumerable;
        internal TRATimestamp_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TRATimestamp_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TRATimestamp_Cell_local_selector(this, expression);
            }
            else
            {
                return new TRATimestamp_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TRATimestamp_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TRATimestamp_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TRATimestamp_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TRATimestamp_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TRATimestamp_Cell> query_tree_gen       = new IndexQueryTreeGenerator<TRATimestamp_Cell>("TRATimestamp_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TRATimestamp_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TRATimestamp_Cell_Accessor_local_selector : IQueryable<TRATimestamp_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         TRATimestamp_Cell_Accessor_local_query_provider    query_provider;
        private TRATimestamp_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TRATimestamp_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TRATimestamp_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TRATimestamp_Cell_Accessor_local_selector(TRATimestamp_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TRATimestamp_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TRATimestamp_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TRATimestamp_Cell_Accessor); }
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
        public PLINQWrapper<TRATimestamp_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<TRATimestamp_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TRATimestamp_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TRATimestamp_Cell_local_selector : IQueryable<TRATimestamp_Cell>, IOrderedQueryable<TRATimestamp_Cell>
    {
        private         Expression                                   query_expression;
        private         TRATimestamp_Cell_local_query_provider             query_provider;
        private TRATimestamp_Cell_local_selector() { /* nobody should reach this method */ }
        internal TRATimestamp_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TRATimestamp_Cell_local_query_provider(storage, tx);
        }
        internal unsafe TRATimestamp_Cell_local_selector(TRATimestamp_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TRATimestamp_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TRATimestamp_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TRATimestamp_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TRATimestamp_Cell); }
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
     * Accepts transformation from TDWGeoLocation_Cell_Accessor to T.
     * </summary>
     */
    internal class TDWGeoLocation_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWGeoLocation_Cell_Accessor_local_query_provider    query_provider;
        internal TDWGeoLocation_Cell_Accessor_local_projector(TDWGeoLocation_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TDWGeoLocation_Cell to T.
     */
    internal class TDWGeoLocation_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWGeoLocation_Cell_local_query_provider             query_provider;
        internal TDWGeoLocation_Cell_local_projector(TDWGeoLocation_Cell_local_query_provider provider, Expression expression)
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
    internal class TDWGeoLocation_Cell_AccessorEnumerable : IEnumerable<TDWGeoLocation_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TDWGeoLocation_Cell_Accessor,bool> m_filter_predicate;
        internal TDWGeoLocation_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWGeoLocation_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWGeoLocation_Cell)
                        {
                            var accessor = TDWGeoLocation_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWGeoLocation_Cell)
                        {
                            var accessor = TDWGeoLocation_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWGeoLocation_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWGeoLocation_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWGeoLocation_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWGeoLocation_Cell_Enumerable : IEnumerable<TDWGeoLocation_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TDWGeoLocation_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TDWGeoLocation_Cell);
        private LocalTransactionContext m_tx;
        internal TDWGeoLocation_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWGeoLocation_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWGeoLocation_Cell)
                        {
                            var accessor = TDWGeoLocation_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWGeoLocation_Cell)
                        {
                            var accessor = TDWGeoLocation_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWGeoLocation_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWGeoLocation_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWGeoLocation_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWGeoLocation_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TDWGeoLocation_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(TDWGeoLocation_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWGeoLocation_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal TDWGeoLocation_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TDWGeoLocation_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TDWGeoLocation_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TDWGeoLocation_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWGeoLocation_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TDWGeoLocation_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWGeoLocation_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWGeoLocation_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWGeoLocation_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TDWGeoLocation_Cell_Accessor>("TDWGeoLocation_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TDWGeoLocation_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TDWGeoLocation_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWGeoLocation_Cell_Enumerable           s_cell_enumerable;
        internal TDWGeoLocation_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TDWGeoLocation_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TDWGeoLocation_Cell_local_selector(this, expression);
            }
            else
            {
                return new TDWGeoLocation_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWGeoLocation_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TDWGeoLocation_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWGeoLocation_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWGeoLocation_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWGeoLocation_Cell> query_tree_gen       = new IndexQueryTreeGenerator<TDWGeoLocation_Cell>("TDWGeoLocation_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TDWGeoLocation_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWGeoLocation_Cell_Accessor_local_selector : IQueryable<TDWGeoLocation_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         TDWGeoLocation_Cell_Accessor_local_query_provider    query_provider;
        private TDWGeoLocation_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TDWGeoLocation_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWGeoLocation_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TDWGeoLocation_Cell_Accessor_local_selector(TDWGeoLocation_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TDWGeoLocation_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWGeoLocation_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWGeoLocation_Cell_Accessor); }
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
        public PLINQWrapper<TDWGeoLocation_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<TDWGeoLocation_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TDWGeoLocation_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWGeoLocation_Cell_local_selector : IQueryable<TDWGeoLocation_Cell>, IOrderedQueryable<TDWGeoLocation_Cell>
    {
        private         Expression                                   query_expression;
        private         TDWGeoLocation_Cell_local_query_provider             query_provider;
        private TDWGeoLocation_Cell_local_selector() { /* nobody should reach this method */ }
        internal TDWGeoLocation_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWGeoLocation_Cell_local_query_provider(storage, tx);
        }
        internal unsafe TDWGeoLocation_Cell_local_selector(TDWGeoLocation_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TDWGeoLocation_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWGeoLocation_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TDWGeoLocation_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWGeoLocation_Cell); }
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
     * Accepts transformation from TRAPostalAddress_Cell_Accessor to T.
     * </summary>
     */
    internal class TRAPostalAddress_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TRAPostalAddress_Cell_Accessor_local_query_provider    query_provider;
        internal TRAPostalAddress_Cell_Accessor_local_projector(TRAPostalAddress_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TRAPostalAddress_Cell to T.
     */
    internal class TRAPostalAddress_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TRAPostalAddress_Cell_local_query_provider             query_provider;
        internal TRAPostalAddress_Cell_local_projector(TRAPostalAddress_Cell_local_query_provider provider, Expression expression)
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
    internal class TRAPostalAddress_Cell_AccessorEnumerable : IEnumerable<TRAPostalAddress_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TRAPostalAddress_Cell_Accessor,bool> m_filter_predicate;
        internal TRAPostalAddress_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TRAPostalAddress_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRAPostalAddress_Cell)
                        {
                            var accessor = TRAPostalAddress_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRAPostalAddress_Cell)
                        {
                            var accessor = TRAPostalAddress_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTRAPostalAddress_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTRAPostalAddress_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TRAPostalAddress_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TRAPostalAddress_Cell_Enumerable : IEnumerable<TRAPostalAddress_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TRAPostalAddress_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TRAPostalAddress_Cell);
        private LocalTransactionContext m_tx;
        internal TRAPostalAddress_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TRAPostalAddress_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRAPostalAddress_Cell)
                        {
                            var accessor = TRAPostalAddress_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRAPostalAddress_Cell)
                        {
                            var accessor = TRAPostalAddress_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTRAPostalAddress_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTRAPostalAddress_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TRAPostalAddress_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TRAPostalAddress_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TRAPostalAddress_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(TRAPostalAddress_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TRAPostalAddress_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal TRAPostalAddress_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TRAPostalAddress_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TRAPostalAddress_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TRAPostalAddress_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TRAPostalAddress_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TRAPostalAddress_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TRAPostalAddress_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TRAPostalAddress_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TRAPostalAddress_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TRAPostalAddress_Cell_Accessor>("TRAPostalAddress_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TRAPostalAddress_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TRAPostalAddress_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TRAPostalAddress_Cell_Enumerable           s_cell_enumerable;
        internal TRAPostalAddress_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TRAPostalAddress_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TRAPostalAddress_Cell_local_selector(this, expression);
            }
            else
            {
                return new TRAPostalAddress_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TRAPostalAddress_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TRAPostalAddress_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TRAPostalAddress_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TRAPostalAddress_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TRAPostalAddress_Cell> query_tree_gen       = new IndexQueryTreeGenerator<TRAPostalAddress_Cell>("TRAPostalAddress_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TRAPostalAddress_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TRAPostalAddress_Cell_Accessor_local_selector : IQueryable<TRAPostalAddress_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         TRAPostalAddress_Cell_Accessor_local_query_provider    query_provider;
        private TRAPostalAddress_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TRAPostalAddress_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TRAPostalAddress_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TRAPostalAddress_Cell_Accessor_local_selector(TRAPostalAddress_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TRAPostalAddress_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TRAPostalAddress_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TRAPostalAddress_Cell_Accessor); }
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
        public PLINQWrapper<TRAPostalAddress_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<TRAPostalAddress_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TRAPostalAddress_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TRAPostalAddress_Cell_local_selector : IQueryable<TRAPostalAddress_Cell>, IOrderedQueryable<TRAPostalAddress_Cell>
    {
        private         Expression                                   query_expression;
        private         TRAPostalAddress_Cell_local_query_provider             query_provider;
        private TRAPostalAddress_Cell_local_selector() { /* nobody should reach this method */ }
        internal TRAPostalAddress_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TRAPostalAddress_Cell_local_query_provider(storage, tx);
        }
        internal unsafe TRAPostalAddress_Cell_local_selector(TRAPostalAddress_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TRAPostalAddress_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TRAPostalAddress_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TRAPostalAddress_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TRAPostalAddress_Cell); }
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
     * Accepts transformation from Cac_Item_Cell_Accessor to T.
     * </summary>
     */
    internal class Cac_Item_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_Item_Cell_Accessor_local_query_provider    query_provider;
        internal Cac_Item_Cell_Accessor_local_projector(Cac_Item_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from Cac_Item_Cell to T.
     */
    internal class Cac_Item_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_Item_Cell_local_query_provider             query_provider;
        internal Cac_Item_Cell_local_projector(Cac_Item_Cell_local_query_provider provider, Expression expression)
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
    internal class Cac_Item_Cell_AccessorEnumerable : IEnumerable<Cac_Item_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<Cac_Item_Cell_Accessor,bool> m_filter_predicate;
        internal Cac_Item_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_Item_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Item_Cell)
                        {
                            var accessor = Cac_Item_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Item_Cell)
                        {
                            var accessor = Cac_Item_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_Item_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_Item_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_Item_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_Item_Cell_Enumerable : IEnumerable<Cac_Item_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<Cac_Item_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(Cac_Item_Cell);
        private LocalTransactionContext m_tx;
        internal Cac_Item_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_Item_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Item_Cell)
                        {
                            var accessor = Cac_Item_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Item_Cell)
                        {
                            var accessor = Cac_Item_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_Item_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_Item_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_Item_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_Item_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(Cac_Item_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(Cac_Item_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_Item_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal Cac_Item_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new Cac_Item_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new Cac_Item_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new Cac_Item_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_Item_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<Cac_Item_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_Item_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_Item_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_Item_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<Cac_Item_Cell_Accessor>("Cac_Item_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class Cac_Item_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(Cac_Item_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_Item_Cell_Enumerable           s_cell_enumerable;
        internal Cac_Item_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new Cac_Item_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new Cac_Item_Cell_local_selector(this, expression);
            }
            else
            {
                return new Cac_Item_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_Item_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<Cac_Item_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_Item_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_Item_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_Item_Cell> query_tree_gen       = new IndexQueryTreeGenerator<Cac_Item_Cell>("Cac_Item_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{Cac_Item_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_Item_Cell_Accessor_local_selector : IQueryable<Cac_Item_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         Cac_Item_Cell_Accessor_local_query_provider    query_provider;
        private Cac_Item_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal Cac_Item_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_Item_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe Cac_Item_Cell_Accessor_local_selector(Cac_Item_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<Cac_Item_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_Item_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_Item_Cell_Accessor); }
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
        public PLINQWrapper<Cac_Item_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<Cac_Item_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{Cac_Item_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_Item_Cell_local_selector : IQueryable<Cac_Item_Cell>, IOrderedQueryable<Cac_Item_Cell>
    {
        private         Expression                                   query_expression;
        private         Cac_Item_Cell_local_query_provider             query_provider;
        private Cac_Item_Cell_local_selector() { /* nobody should reach this method */ }
        internal Cac_Item_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_Item_Cell_local_query_provider(storage, tx);
        }
        internal unsafe Cac_Item_Cell_local_selector(Cac_Item_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<Cac_Item_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_Item_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<Cac_Item_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_Item_Cell); }
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
     * Accepts transformation from Cac_ExternalReference_Cell_Accessor to T.
     * </summary>
     */
    internal class Cac_ExternalReference_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_ExternalReference_Cell_Accessor_local_query_provider    query_provider;
        internal Cac_ExternalReference_Cell_Accessor_local_projector(Cac_ExternalReference_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from Cac_ExternalReference_Cell to T.
     */
    internal class Cac_ExternalReference_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_ExternalReference_Cell_local_query_provider             query_provider;
        internal Cac_ExternalReference_Cell_local_projector(Cac_ExternalReference_Cell_local_query_provider provider, Expression expression)
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
    internal class Cac_ExternalReference_Cell_AccessorEnumerable : IEnumerable<Cac_ExternalReference_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<Cac_ExternalReference_Cell_Accessor,bool> m_filter_predicate;
        internal Cac_ExternalReference_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_ExternalReference_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_ExternalReference_Cell)
                        {
                            var accessor = Cac_ExternalReference_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_ExternalReference_Cell)
                        {
                            var accessor = Cac_ExternalReference_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_ExternalReference_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_ExternalReference_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_ExternalReference_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_ExternalReference_Cell_Enumerable : IEnumerable<Cac_ExternalReference_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<Cac_ExternalReference_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(Cac_ExternalReference_Cell);
        private LocalTransactionContext m_tx;
        internal Cac_ExternalReference_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_ExternalReference_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_ExternalReference_Cell)
                        {
                            var accessor = Cac_ExternalReference_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_ExternalReference_Cell)
                        {
                            var accessor = Cac_ExternalReference_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_ExternalReference_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_ExternalReference_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_ExternalReference_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_ExternalReference_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(Cac_ExternalReference_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(Cac_ExternalReference_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_ExternalReference_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal Cac_ExternalReference_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new Cac_ExternalReference_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new Cac_ExternalReference_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new Cac_ExternalReference_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_ExternalReference_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<Cac_ExternalReference_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_ExternalReference_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_ExternalReference_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_ExternalReference_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<Cac_ExternalReference_Cell_Accessor>("Cac_ExternalReference_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class Cac_ExternalReference_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(Cac_ExternalReference_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_ExternalReference_Cell_Enumerable           s_cell_enumerable;
        internal Cac_ExternalReference_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new Cac_ExternalReference_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new Cac_ExternalReference_Cell_local_selector(this, expression);
            }
            else
            {
                return new Cac_ExternalReference_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_ExternalReference_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<Cac_ExternalReference_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_ExternalReference_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_ExternalReference_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_ExternalReference_Cell> query_tree_gen       = new IndexQueryTreeGenerator<Cac_ExternalReference_Cell>("Cac_ExternalReference_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{Cac_ExternalReference_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_ExternalReference_Cell_Accessor_local_selector : IQueryable<Cac_ExternalReference_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         Cac_ExternalReference_Cell_Accessor_local_query_provider    query_provider;
        private Cac_ExternalReference_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal Cac_ExternalReference_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_ExternalReference_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe Cac_ExternalReference_Cell_Accessor_local_selector(Cac_ExternalReference_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<Cac_ExternalReference_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_ExternalReference_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_ExternalReference_Cell_Accessor); }
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
        public PLINQWrapper<Cac_ExternalReference_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<Cac_ExternalReference_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{Cac_ExternalReference_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_ExternalReference_Cell_local_selector : IQueryable<Cac_ExternalReference_Cell>, IOrderedQueryable<Cac_ExternalReference_Cell>
    {
        private         Expression                                   query_expression;
        private         Cac_ExternalReference_Cell_local_query_provider             query_provider;
        private Cac_ExternalReference_Cell_local_selector() { /* nobody should reach this method */ }
        internal Cac_ExternalReference_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_ExternalReference_Cell_local_query_provider(storage, tx);
        }
        internal unsafe Cac_ExternalReference_Cell_local_selector(Cac_ExternalReference_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<Cac_ExternalReference_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_ExternalReference_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<Cac_ExternalReference_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_ExternalReference_Cell); }
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
     * Accepts transformation from Cac_Address_Cell_Accessor to T.
     * </summary>
     */
    internal class Cac_Address_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_Address_Cell_Accessor_local_query_provider    query_provider;
        internal Cac_Address_Cell_Accessor_local_projector(Cac_Address_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from Cac_Address_Cell to T.
     */
    internal class Cac_Address_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_Address_Cell_local_query_provider             query_provider;
        internal Cac_Address_Cell_local_projector(Cac_Address_Cell_local_query_provider provider, Expression expression)
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
    internal class Cac_Address_Cell_AccessorEnumerable : IEnumerable<Cac_Address_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<Cac_Address_Cell_Accessor,bool> m_filter_predicate;
        internal Cac_Address_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_Address_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Address_Cell)
                        {
                            var accessor = Cac_Address_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Address_Cell)
                        {
                            var accessor = Cac_Address_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_Address_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_Address_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_Address_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_Address_Cell_Enumerable : IEnumerable<Cac_Address_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<Cac_Address_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(Cac_Address_Cell);
        private LocalTransactionContext m_tx;
        internal Cac_Address_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_Address_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Address_Cell)
                        {
                            var accessor = Cac_Address_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Address_Cell)
                        {
                            var accessor = Cac_Address_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_Address_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_Address_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_Address_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_Address_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(Cac_Address_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(Cac_Address_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_Address_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal Cac_Address_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new Cac_Address_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new Cac_Address_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new Cac_Address_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_Address_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<Cac_Address_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_Address_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_Address_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_Address_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<Cac_Address_Cell_Accessor>("Cac_Address_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class Cac_Address_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(Cac_Address_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_Address_Cell_Enumerable           s_cell_enumerable;
        internal Cac_Address_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new Cac_Address_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new Cac_Address_Cell_local_selector(this, expression);
            }
            else
            {
                return new Cac_Address_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_Address_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<Cac_Address_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_Address_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_Address_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_Address_Cell> query_tree_gen       = new IndexQueryTreeGenerator<Cac_Address_Cell>("Cac_Address_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{Cac_Address_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_Address_Cell_Accessor_local_selector : IQueryable<Cac_Address_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         Cac_Address_Cell_Accessor_local_query_provider    query_provider;
        private Cac_Address_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal Cac_Address_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_Address_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe Cac_Address_Cell_Accessor_local_selector(Cac_Address_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<Cac_Address_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_Address_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_Address_Cell_Accessor); }
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
        public PLINQWrapper<Cac_Address_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<Cac_Address_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{Cac_Address_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_Address_Cell_local_selector : IQueryable<Cac_Address_Cell>, IOrderedQueryable<Cac_Address_Cell>
    {
        private         Expression                                   query_expression;
        private         Cac_Address_Cell_local_query_provider             query_provider;
        private Cac_Address_Cell_local_selector() { /* nobody should reach this method */ }
        internal Cac_Address_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_Address_Cell_local_query_provider(storage, tx);
        }
        internal unsafe Cac_Address_Cell_local_selector(Cac_Address_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<Cac_Address_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_Address_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<Cac_Address_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_Address_Cell); }
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
     * Accepts transformation from Cac_PostalAddress_Cell_Accessor to T.
     * </summary>
     */
    internal class Cac_PostalAddress_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_PostalAddress_Cell_Accessor_local_query_provider    query_provider;
        internal Cac_PostalAddress_Cell_Accessor_local_projector(Cac_PostalAddress_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from Cac_PostalAddress_Cell to T.
     */
    internal class Cac_PostalAddress_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_PostalAddress_Cell_local_query_provider             query_provider;
        internal Cac_PostalAddress_Cell_local_projector(Cac_PostalAddress_Cell_local_query_provider provider, Expression expression)
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
    internal class Cac_PostalAddress_Cell_AccessorEnumerable : IEnumerable<Cac_PostalAddress_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<Cac_PostalAddress_Cell_Accessor,bool> m_filter_predicate;
        internal Cac_PostalAddress_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_PostalAddress_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PostalAddress_Cell)
                        {
                            var accessor = Cac_PostalAddress_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PostalAddress_Cell)
                        {
                            var accessor = Cac_PostalAddress_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_PostalAddress_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_PostalAddress_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_PostalAddress_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_PostalAddress_Cell_Enumerable : IEnumerable<Cac_PostalAddress_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<Cac_PostalAddress_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(Cac_PostalAddress_Cell);
        private LocalTransactionContext m_tx;
        internal Cac_PostalAddress_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_PostalAddress_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PostalAddress_Cell)
                        {
                            var accessor = Cac_PostalAddress_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PostalAddress_Cell)
                        {
                            var accessor = Cac_PostalAddress_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_PostalAddress_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_PostalAddress_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_PostalAddress_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_PostalAddress_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(Cac_PostalAddress_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(Cac_PostalAddress_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_PostalAddress_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal Cac_PostalAddress_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new Cac_PostalAddress_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new Cac_PostalAddress_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new Cac_PostalAddress_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_PostalAddress_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<Cac_PostalAddress_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_PostalAddress_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_PostalAddress_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_PostalAddress_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<Cac_PostalAddress_Cell_Accessor>("Cac_PostalAddress_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class Cac_PostalAddress_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(Cac_PostalAddress_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_PostalAddress_Cell_Enumerable           s_cell_enumerable;
        internal Cac_PostalAddress_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new Cac_PostalAddress_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new Cac_PostalAddress_Cell_local_selector(this, expression);
            }
            else
            {
                return new Cac_PostalAddress_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_PostalAddress_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<Cac_PostalAddress_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_PostalAddress_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_PostalAddress_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_PostalAddress_Cell> query_tree_gen       = new IndexQueryTreeGenerator<Cac_PostalAddress_Cell>("Cac_PostalAddress_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{Cac_PostalAddress_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_PostalAddress_Cell_Accessor_local_selector : IQueryable<Cac_PostalAddress_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         Cac_PostalAddress_Cell_Accessor_local_query_provider    query_provider;
        private Cac_PostalAddress_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal Cac_PostalAddress_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_PostalAddress_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe Cac_PostalAddress_Cell_Accessor_local_selector(Cac_PostalAddress_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<Cac_PostalAddress_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_PostalAddress_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_PostalAddress_Cell_Accessor); }
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
        public PLINQWrapper<Cac_PostalAddress_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<Cac_PostalAddress_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{Cac_PostalAddress_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_PostalAddress_Cell_local_selector : IQueryable<Cac_PostalAddress_Cell>, IOrderedQueryable<Cac_PostalAddress_Cell>
    {
        private         Expression                                   query_expression;
        private         Cac_PostalAddress_Cell_local_query_provider             query_provider;
        private Cac_PostalAddress_Cell_local_selector() { /* nobody should reach this method */ }
        internal Cac_PostalAddress_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_PostalAddress_Cell_local_query_provider(storage, tx);
        }
        internal unsafe Cac_PostalAddress_Cell_local_selector(Cac_PostalAddress_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<Cac_PostalAddress_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_PostalAddress_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<Cac_PostalAddress_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_PostalAddress_Cell); }
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
     * Accepts transformation from Cac_PartyLegalEntity_Cell_Accessor to T.
     * </summary>
     */
    internal class Cac_PartyLegalEntity_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_PartyLegalEntity_Cell_Accessor_local_query_provider    query_provider;
        internal Cac_PartyLegalEntity_Cell_Accessor_local_projector(Cac_PartyLegalEntity_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from Cac_PartyLegalEntity_Cell to T.
     */
    internal class Cac_PartyLegalEntity_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_PartyLegalEntity_Cell_local_query_provider             query_provider;
        internal Cac_PartyLegalEntity_Cell_local_projector(Cac_PartyLegalEntity_Cell_local_query_provider provider, Expression expression)
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
    internal class Cac_PartyLegalEntity_Cell_AccessorEnumerable : IEnumerable<Cac_PartyLegalEntity_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<Cac_PartyLegalEntity_Cell_Accessor,bool> m_filter_predicate;
        internal Cac_PartyLegalEntity_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_PartyLegalEntity_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PartyLegalEntity_Cell)
                        {
                            var accessor = Cac_PartyLegalEntity_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PartyLegalEntity_Cell)
                        {
                            var accessor = Cac_PartyLegalEntity_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_PartyLegalEntity_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_PartyLegalEntity_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_PartyLegalEntity_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_PartyLegalEntity_Cell_Enumerable : IEnumerable<Cac_PartyLegalEntity_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<Cac_PartyLegalEntity_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(Cac_PartyLegalEntity_Cell);
        private LocalTransactionContext m_tx;
        internal Cac_PartyLegalEntity_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_PartyLegalEntity_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PartyLegalEntity_Cell)
                        {
                            var accessor = Cac_PartyLegalEntity_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PartyLegalEntity_Cell)
                        {
                            var accessor = Cac_PartyLegalEntity_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_PartyLegalEntity_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_PartyLegalEntity_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_PartyLegalEntity_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_PartyLegalEntity_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(Cac_PartyLegalEntity_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(Cac_PartyLegalEntity_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_PartyLegalEntity_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal Cac_PartyLegalEntity_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new Cac_PartyLegalEntity_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new Cac_PartyLegalEntity_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new Cac_PartyLegalEntity_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_PartyLegalEntity_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<Cac_PartyLegalEntity_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_PartyLegalEntity_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_PartyLegalEntity_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_PartyLegalEntity_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<Cac_PartyLegalEntity_Cell_Accessor>("Cac_PartyLegalEntity_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class Cac_PartyLegalEntity_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(Cac_PartyLegalEntity_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_PartyLegalEntity_Cell_Enumerable           s_cell_enumerable;
        internal Cac_PartyLegalEntity_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new Cac_PartyLegalEntity_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new Cac_PartyLegalEntity_Cell_local_selector(this, expression);
            }
            else
            {
                return new Cac_PartyLegalEntity_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_PartyLegalEntity_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<Cac_PartyLegalEntity_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_PartyLegalEntity_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_PartyLegalEntity_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_PartyLegalEntity_Cell> query_tree_gen       = new IndexQueryTreeGenerator<Cac_PartyLegalEntity_Cell>("Cac_PartyLegalEntity_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{Cac_PartyLegalEntity_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_PartyLegalEntity_Cell_Accessor_local_selector : IQueryable<Cac_PartyLegalEntity_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         Cac_PartyLegalEntity_Cell_Accessor_local_query_provider    query_provider;
        private Cac_PartyLegalEntity_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal Cac_PartyLegalEntity_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_PartyLegalEntity_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe Cac_PartyLegalEntity_Cell_Accessor_local_selector(Cac_PartyLegalEntity_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<Cac_PartyLegalEntity_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_PartyLegalEntity_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_PartyLegalEntity_Cell_Accessor); }
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
        public PLINQWrapper<Cac_PartyLegalEntity_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<Cac_PartyLegalEntity_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{Cac_PartyLegalEntity_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_PartyLegalEntity_Cell_local_selector : IQueryable<Cac_PartyLegalEntity_Cell>, IOrderedQueryable<Cac_PartyLegalEntity_Cell>
    {
        private         Expression                                   query_expression;
        private         Cac_PartyLegalEntity_Cell_local_query_provider             query_provider;
        private Cac_PartyLegalEntity_Cell_local_selector() { /* nobody should reach this method */ }
        internal Cac_PartyLegalEntity_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_PartyLegalEntity_Cell_local_query_provider(storage, tx);
        }
        internal unsafe Cac_PartyLegalEntity_Cell_local_selector(Cac_PartyLegalEntity_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<Cac_PartyLegalEntity_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_PartyLegalEntity_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<Cac_PartyLegalEntity_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_PartyLegalEntity_Cell); }
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
     * Accepts transformation from Cac_Contact_Cell_Accessor to T.
     * </summary>
     */
    internal class Cac_Contact_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_Contact_Cell_Accessor_local_query_provider    query_provider;
        internal Cac_Contact_Cell_Accessor_local_projector(Cac_Contact_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from Cac_Contact_Cell to T.
     */
    internal class Cac_Contact_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_Contact_Cell_local_query_provider             query_provider;
        internal Cac_Contact_Cell_local_projector(Cac_Contact_Cell_local_query_provider provider, Expression expression)
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
    internal class Cac_Contact_Cell_AccessorEnumerable : IEnumerable<Cac_Contact_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<Cac_Contact_Cell_Accessor,bool> m_filter_predicate;
        internal Cac_Contact_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_Contact_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Contact_Cell)
                        {
                            var accessor = Cac_Contact_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Contact_Cell)
                        {
                            var accessor = Cac_Contact_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_Contact_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_Contact_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_Contact_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_Contact_Cell_Enumerable : IEnumerable<Cac_Contact_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<Cac_Contact_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(Cac_Contact_Cell);
        private LocalTransactionContext m_tx;
        internal Cac_Contact_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_Contact_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Contact_Cell)
                        {
                            var accessor = Cac_Contact_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Contact_Cell)
                        {
                            var accessor = Cac_Contact_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_Contact_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_Contact_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_Contact_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_Contact_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(Cac_Contact_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(Cac_Contact_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_Contact_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal Cac_Contact_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new Cac_Contact_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new Cac_Contact_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new Cac_Contact_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_Contact_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<Cac_Contact_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_Contact_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_Contact_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_Contact_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<Cac_Contact_Cell_Accessor>("Cac_Contact_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class Cac_Contact_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(Cac_Contact_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_Contact_Cell_Enumerable           s_cell_enumerable;
        internal Cac_Contact_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new Cac_Contact_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new Cac_Contact_Cell_local_selector(this, expression);
            }
            else
            {
                return new Cac_Contact_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_Contact_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<Cac_Contact_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_Contact_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_Contact_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_Contact_Cell> query_tree_gen       = new IndexQueryTreeGenerator<Cac_Contact_Cell>("Cac_Contact_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{Cac_Contact_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_Contact_Cell_Accessor_local_selector : IQueryable<Cac_Contact_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         Cac_Contact_Cell_Accessor_local_query_provider    query_provider;
        private Cac_Contact_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal Cac_Contact_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_Contact_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe Cac_Contact_Cell_Accessor_local_selector(Cac_Contact_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<Cac_Contact_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_Contact_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_Contact_Cell_Accessor); }
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
        public PLINQWrapper<Cac_Contact_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<Cac_Contact_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{Cac_Contact_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_Contact_Cell_local_selector : IQueryable<Cac_Contact_Cell>, IOrderedQueryable<Cac_Contact_Cell>
    {
        private         Expression                                   query_expression;
        private         Cac_Contact_Cell_local_query_provider             query_provider;
        private Cac_Contact_Cell_local_selector() { /* nobody should reach this method */ }
        internal Cac_Contact_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_Contact_Cell_local_query_provider(storage, tx);
        }
        internal unsafe Cac_Contact_Cell_local_selector(Cac_Contact_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<Cac_Contact_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_Contact_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<Cac_Contact_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_Contact_Cell); }
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
     * Accepts transformation from Cac_Person_Cell_Accessor to T.
     * </summary>
     */
    internal class Cac_Person_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_Person_Cell_Accessor_local_query_provider    query_provider;
        internal Cac_Person_Cell_Accessor_local_projector(Cac_Person_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from Cac_Person_Cell to T.
     */
    internal class Cac_Person_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_Person_Cell_local_query_provider             query_provider;
        internal Cac_Person_Cell_local_projector(Cac_Person_Cell_local_query_provider provider, Expression expression)
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
    internal class Cac_Person_Cell_AccessorEnumerable : IEnumerable<Cac_Person_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<Cac_Person_Cell_Accessor,bool> m_filter_predicate;
        internal Cac_Person_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_Person_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Person_Cell)
                        {
                            var accessor = Cac_Person_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Person_Cell)
                        {
                            var accessor = Cac_Person_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_Person_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_Person_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_Person_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_Person_Cell_Enumerable : IEnumerable<Cac_Person_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<Cac_Person_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(Cac_Person_Cell);
        private LocalTransactionContext m_tx;
        internal Cac_Person_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_Person_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Person_Cell)
                        {
                            var accessor = Cac_Person_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Person_Cell)
                        {
                            var accessor = Cac_Person_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_Person_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_Person_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_Person_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_Person_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(Cac_Person_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(Cac_Person_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_Person_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal Cac_Person_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new Cac_Person_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new Cac_Person_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new Cac_Person_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_Person_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<Cac_Person_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_Person_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_Person_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_Person_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<Cac_Person_Cell_Accessor>("Cac_Person_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class Cac_Person_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(Cac_Person_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_Person_Cell_Enumerable           s_cell_enumerable;
        internal Cac_Person_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new Cac_Person_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new Cac_Person_Cell_local_selector(this, expression);
            }
            else
            {
                return new Cac_Person_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_Person_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<Cac_Person_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_Person_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_Person_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_Person_Cell> query_tree_gen       = new IndexQueryTreeGenerator<Cac_Person_Cell>("Cac_Person_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{Cac_Person_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_Person_Cell_Accessor_local_selector : IQueryable<Cac_Person_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         Cac_Person_Cell_Accessor_local_query_provider    query_provider;
        private Cac_Person_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal Cac_Person_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_Person_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe Cac_Person_Cell_Accessor_local_selector(Cac_Person_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<Cac_Person_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_Person_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_Person_Cell_Accessor); }
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
        public PLINQWrapper<Cac_Person_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<Cac_Person_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{Cac_Person_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_Person_Cell_local_selector : IQueryable<Cac_Person_Cell>, IOrderedQueryable<Cac_Person_Cell>
    {
        private         Expression                                   query_expression;
        private         Cac_Person_Cell_local_query_provider             query_provider;
        private Cac_Person_Cell_local_selector() { /* nobody should reach this method */ }
        internal Cac_Person_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_Person_Cell_local_query_provider(storage, tx);
        }
        internal unsafe Cac_Person_Cell_local_selector(Cac_Person_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<Cac_Person_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_Person_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<Cac_Person_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_Person_Cell); }
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
     * Accepts transformation from Cac_PaymentMeans_Cell_Accessor to T.
     * </summary>
     */
    internal class Cac_PaymentMeans_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_PaymentMeans_Cell_Accessor_local_query_provider    query_provider;
        internal Cac_PaymentMeans_Cell_Accessor_local_projector(Cac_PaymentMeans_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from Cac_PaymentMeans_Cell to T.
     */
    internal class Cac_PaymentMeans_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_PaymentMeans_Cell_local_query_provider             query_provider;
        internal Cac_PaymentMeans_Cell_local_projector(Cac_PaymentMeans_Cell_local_query_provider provider, Expression expression)
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
    internal class Cac_PaymentMeans_Cell_AccessorEnumerable : IEnumerable<Cac_PaymentMeans_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<Cac_PaymentMeans_Cell_Accessor,bool> m_filter_predicate;
        internal Cac_PaymentMeans_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_PaymentMeans_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PaymentMeans_Cell)
                        {
                            var accessor = Cac_PaymentMeans_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PaymentMeans_Cell)
                        {
                            var accessor = Cac_PaymentMeans_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_PaymentMeans_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_PaymentMeans_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_PaymentMeans_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_PaymentMeans_Cell_Enumerable : IEnumerable<Cac_PaymentMeans_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<Cac_PaymentMeans_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(Cac_PaymentMeans_Cell);
        private LocalTransactionContext m_tx;
        internal Cac_PaymentMeans_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_PaymentMeans_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PaymentMeans_Cell)
                        {
                            var accessor = Cac_PaymentMeans_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PaymentMeans_Cell)
                        {
                            var accessor = Cac_PaymentMeans_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_PaymentMeans_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_PaymentMeans_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_PaymentMeans_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_PaymentMeans_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(Cac_PaymentMeans_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(Cac_PaymentMeans_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_PaymentMeans_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal Cac_PaymentMeans_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new Cac_PaymentMeans_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new Cac_PaymentMeans_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new Cac_PaymentMeans_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_PaymentMeans_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<Cac_PaymentMeans_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_PaymentMeans_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_PaymentMeans_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_PaymentMeans_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<Cac_PaymentMeans_Cell_Accessor>("Cac_PaymentMeans_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class Cac_PaymentMeans_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(Cac_PaymentMeans_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_PaymentMeans_Cell_Enumerable           s_cell_enumerable;
        internal Cac_PaymentMeans_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new Cac_PaymentMeans_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new Cac_PaymentMeans_Cell_local_selector(this, expression);
            }
            else
            {
                return new Cac_PaymentMeans_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_PaymentMeans_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<Cac_PaymentMeans_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_PaymentMeans_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_PaymentMeans_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_PaymentMeans_Cell> query_tree_gen       = new IndexQueryTreeGenerator<Cac_PaymentMeans_Cell>("Cac_PaymentMeans_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{Cac_PaymentMeans_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_PaymentMeans_Cell_Accessor_local_selector : IQueryable<Cac_PaymentMeans_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         Cac_PaymentMeans_Cell_Accessor_local_query_provider    query_provider;
        private Cac_PaymentMeans_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal Cac_PaymentMeans_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_PaymentMeans_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe Cac_PaymentMeans_Cell_Accessor_local_selector(Cac_PaymentMeans_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<Cac_PaymentMeans_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_PaymentMeans_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_PaymentMeans_Cell_Accessor); }
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
        public PLINQWrapper<Cac_PaymentMeans_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<Cac_PaymentMeans_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{Cac_PaymentMeans_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_PaymentMeans_Cell_local_selector : IQueryable<Cac_PaymentMeans_Cell>, IOrderedQueryable<Cac_PaymentMeans_Cell>
    {
        private         Expression                                   query_expression;
        private         Cac_PaymentMeans_Cell_local_query_provider             query_provider;
        private Cac_PaymentMeans_Cell_local_selector() { /* nobody should reach this method */ }
        internal Cac_PaymentMeans_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_PaymentMeans_Cell_local_query_provider(storage, tx);
        }
        internal unsafe Cac_PaymentMeans_Cell_local_selector(Cac_PaymentMeans_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<Cac_PaymentMeans_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_PaymentMeans_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<Cac_PaymentMeans_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_PaymentMeans_Cell); }
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
     * Accepts transformation from Cac_PayeeFinancialAccount_Cell_Accessor to T.
     * </summary>
     */
    internal class Cac_PayeeFinancialAccount_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_PayeeFinancialAccount_Cell_Accessor_local_query_provider    query_provider;
        internal Cac_PayeeFinancialAccount_Cell_Accessor_local_projector(Cac_PayeeFinancialAccount_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from Cac_PayeeFinancialAccount_Cell to T.
     */
    internal class Cac_PayeeFinancialAccount_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_PayeeFinancialAccount_Cell_local_query_provider             query_provider;
        internal Cac_PayeeFinancialAccount_Cell_local_projector(Cac_PayeeFinancialAccount_Cell_local_query_provider provider, Expression expression)
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
    internal class Cac_PayeeFinancialAccount_Cell_AccessorEnumerable : IEnumerable<Cac_PayeeFinancialAccount_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<Cac_PayeeFinancialAccount_Cell_Accessor,bool> m_filter_predicate;
        internal Cac_PayeeFinancialAccount_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_PayeeFinancialAccount_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PayeeFinancialAccount_Cell)
                        {
                            var accessor = Cac_PayeeFinancialAccount_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PayeeFinancialAccount_Cell)
                        {
                            var accessor = Cac_PayeeFinancialAccount_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_PayeeFinancialAccount_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_PayeeFinancialAccount_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_PayeeFinancialAccount_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_PayeeFinancialAccount_Cell_Enumerable : IEnumerable<Cac_PayeeFinancialAccount_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<Cac_PayeeFinancialAccount_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(Cac_PayeeFinancialAccount_Cell);
        private LocalTransactionContext m_tx;
        internal Cac_PayeeFinancialAccount_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_PayeeFinancialAccount_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PayeeFinancialAccount_Cell)
                        {
                            var accessor = Cac_PayeeFinancialAccount_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_PayeeFinancialAccount_Cell)
                        {
                            var accessor = Cac_PayeeFinancialAccount_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_PayeeFinancialAccount_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_PayeeFinancialAccount_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_PayeeFinancialAccount_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_PayeeFinancialAccount_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(Cac_PayeeFinancialAccount_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(Cac_PayeeFinancialAccount_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_PayeeFinancialAccount_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal Cac_PayeeFinancialAccount_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new Cac_PayeeFinancialAccount_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new Cac_PayeeFinancialAccount_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new Cac_PayeeFinancialAccount_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_PayeeFinancialAccount_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<Cac_PayeeFinancialAccount_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_PayeeFinancialAccount_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_PayeeFinancialAccount_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_PayeeFinancialAccount_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<Cac_PayeeFinancialAccount_Cell_Accessor>("Cac_PayeeFinancialAccount_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class Cac_PayeeFinancialAccount_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(Cac_PayeeFinancialAccount_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_PayeeFinancialAccount_Cell_Enumerable           s_cell_enumerable;
        internal Cac_PayeeFinancialAccount_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new Cac_PayeeFinancialAccount_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new Cac_PayeeFinancialAccount_Cell_local_selector(this, expression);
            }
            else
            {
                return new Cac_PayeeFinancialAccount_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_PayeeFinancialAccount_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<Cac_PayeeFinancialAccount_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_PayeeFinancialAccount_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_PayeeFinancialAccount_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_PayeeFinancialAccount_Cell> query_tree_gen       = new IndexQueryTreeGenerator<Cac_PayeeFinancialAccount_Cell>("Cac_PayeeFinancialAccount_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{Cac_PayeeFinancialAccount_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_PayeeFinancialAccount_Cell_Accessor_local_selector : IQueryable<Cac_PayeeFinancialAccount_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         Cac_PayeeFinancialAccount_Cell_Accessor_local_query_provider    query_provider;
        private Cac_PayeeFinancialAccount_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal Cac_PayeeFinancialAccount_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_PayeeFinancialAccount_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe Cac_PayeeFinancialAccount_Cell_Accessor_local_selector(Cac_PayeeFinancialAccount_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<Cac_PayeeFinancialAccount_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_PayeeFinancialAccount_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_PayeeFinancialAccount_Cell_Accessor); }
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
        public PLINQWrapper<Cac_PayeeFinancialAccount_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<Cac_PayeeFinancialAccount_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{Cac_PayeeFinancialAccount_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_PayeeFinancialAccount_Cell_local_selector : IQueryable<Cac_PayeeFinancialAccount_Cell>, IOrderedQueryable<Cac_PayeeFinancialAccount_Cell>
    {
        private         Expression                                   query_expression;
        private         Cac_PayeeFinancialAccount_Cell_local_query_provider             query_provider;
        private Cac_PayeeFinancialAccount_Cell_local_selector() { /* nobody should reach this method */ }
        internal Cac_PayeeFinancialAccount_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_PayeeFinancialAccount_Cell_local_query_provider(storage, tx);
        }
        internal unsafe Cac_PayeeFinancialAccount_Cell_local_selector(Cac_PayeeFinancialAccount_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<Cac_PayeeFinancialAccount_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_PayeeFinancialAccount_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<Cac_PayeeFinancialAccount_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_PayeeFinancialAccount_Cell); }
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
     * Accepts transformation from Cac_Party_Cell_Accessor to T.
     * </summary>
     */
    internal class Cac_Party_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_Party_Cell_Accessor_local_query_provider    query_provider;
        internal Cac_Party_Cell_Accessor_local_projector(Cac_Party_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from Cac_Party_Cell to T.
     */
    internal class Cac_Party_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         Cac_Party_Cell_local_query_provider             query_provider;
        internal Cac_Party_Cell_local_projector(Cac_Party_Cell_local_query_provider provider, Expression expression)
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
    internal class Cac_Party_Cell_AccessorEnumerable : IEnumerable<Cac_Party_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<Cac_Party_Cell_Accessor,bool> m_filter_predicate;
        internal Cac_Party_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_Party_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Party_Cell)
                        {
                            var accessor = Cac_Party_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Party_Cell)
                        {
                            var accessor = Cac_Party_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_Party_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_Party_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_Party_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_Party_Cell_Enumerable : IEnumerable<Cac_Party_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<Cac_Party_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(Cac_Party_Cell);
        private LocalTransactionContext m_tx;
        internal Cac_Party_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<Cac_Party_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Party_Cell)
                        {
                            var accessor = Cac_Party_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.Cac_Party_Cell)
                        {
                            var accessor = Cac_Party_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseCac_Party_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseCac_Party_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<Cac_Party_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class Cac_Party_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(Cac_Party_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(Cac_Party_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_Party_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal Cac_Party_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new Cac_Party_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new Cac_Party_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new Cac_Party_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_Party_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<Cac_Party_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_Party_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_Party_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_Party_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<Cac_Party_Cell_Accessor>("Cac_Party_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class Cac_Party_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(Cac_Party_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         Cac_Party_Cell_Enumerable           s_cell_enumerable;
        internal Cac_Party_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new Cac_Party_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new Cac_Party_Cell_local_selector(this, expression);
            }
            else
            {
                return new Cac_Party_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<Cac_Party_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<Cac_Party_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(Cac_Party_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<Cac_Party_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<Cac_Party_Cell> query_tree_gen       = new IndexQueryTreeGenerator<Cac_Party_Cell>("Cac_Party_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{Cac_Party_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_Party_Cell_Accessor_local_selector : IQueryable<Cac_Party_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         Cac_Party_Cell_Accessor_local_query_provider    query_provider;
        private Cac_Party_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal Cac_Party_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_Party_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe Cac_Party_Cell_Accessor_local_selector(Cac_Party_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<Cac_Party_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_Party_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_Party_Cell_Accessor); }
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
        public PLINQWrapper<Cac_Party_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<Cac_Party_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{Cac_Party_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class Cac_Party_Cell_local_selector : IQueryable<Cac_Party_Cell>, IOrderedQueryable<Cac_Party_Cell>
    {
        private         Expression                                   query_expression;
        private         Cac_Party_Cell_local_query_provider             query_provider;
        private Cac_Party_Cell_local_selector() { /* nobody should reach this method */ }
        internal Cac_Party_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new Cac_Party_Cell_local_query_provider(storage, tx);
        }
        internal unsafe Cac_Party_Cell_local_selector(Cac_Party_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<Cac_Party_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<Cac_Party_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<Cac_Party_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(Cac_Party_Cell); }
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
     * Accepts transformation from UBL21_Invoice2_Cell_Accessor to T.
     * </summary>
     */
    internal class UBL21_Invoice2_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         UBL21_Invoice2_Cell_Accessor_local_query_provider    query_provider;
        internal UBL21_Invoice2_Cell_Accessor_local_projector(UBL21_Invoice2_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from UBL21_Invoice2_Cell to T.
     */
    internal class UBL21_Invoice2_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         UBL21_Invoice2_Cell_local_query_provider             query_provider;
        internal UBL21_Invoice2_Cell_local_projector(UBL21_Invoice2_Cell_local_query_provider provider, Expression expression)
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
    internal class UBL21_Invoice2_Cell_AccessorEnumerable : IEnumerable<UBL21_Invoice2_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<UBL21_Invoice2_Cell_Accessor,bool> m_filter_predicate;
        internal UBL21_Invoice2_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<UBL21_Invoice2_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.UBL21_Invoice2_Cell)
                        {
                            var accessor = UBL21_Invoice2_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.UBL21_Invoice2_Cell)
                        {
                            var accessor = UBL21_Invoice2_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseUBL21_Invoice2_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseUBL21_Invoice2_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<UBL21_Invoice2_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class UBL21_Invoice2_Cell_Enumerable : IEnumerable<UBL21_Invoice2_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<UBL21_Invoice2_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(UBL21_Invoice2_Cell);
        private LocalTransactionContext m_tx;
        internal UBL21_Invoice2_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<UBL21_Invoice2_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.UBL21_Invoice2_Cell)
                        {
                            var accessor = UBL21_Invoice2_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.UBL21_Invoice2_Cell)
                        {
                            var accessor = UBL21_Invoice2_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseUBL21_Invoice2_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseUBL21_Invoice2_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<UBL21_Invoice2_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class UBL21_Invoice2_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(UBL21_Invoice2_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(UBL21_Invoice2_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         UBL21_Invoice2_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal UBL21_Invoice2_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new UBL21_Invoice2_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new UBL21_Invoice2_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new UBL21_Invoice2_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<UBL21_Invoice2_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<UBL21_Invoice2_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(UBL21_Invoice2_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<UBL21_Invoice2_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<UBL21_Invoice2_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<UBL21_Invoice2_Cell_Accessor>("UBL21_Invoice2_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class UBL21_Invoice2_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(UBL21_Invoice2_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         UBL21_Invoice2_Cell_Enumerable           s_cell_enumerable;
        internal UBL21_Invoice2_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new UBL21_Invoice2_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new UBL21_Invoice2_Cell_local_selector(this, expression);
            }
            else
            {
                return new UBL21_Invoice2_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<UBL21_Invoice2_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<UBL21_Invoice2_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(UBL21_Invoice2_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<UBL21_Invoice2_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<UBL21_Invoice2_Cell> query_tree_gen       = new IndexQueryTreeGenerator<UBL21_Invoice2_Cell>("UBL21_Invoice2_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{UBL21_Invoice2_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class UBL21_Invoice2_Cell_Accessor_local_selector : IQueryable<UBL21_Invoice2_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         UBL21_Invoice2_Cell_Accessor_local_query_provider    query_provider;
        private UBL21_Invoice2_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal UBL21_Invoice2_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new UBL21_Invoice2_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe UBL21_Invoice2_Cell_Accessor_local_selector(UBL21_Invoice2_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<UBL21_Invoice2_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<UBL21_Invoice2_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(UBL21_Invoice2_Cell_Accessor); }
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
        public PLINQWrapper<UBL21_Invoice2_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<UBL21_Invoice2_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{UBL21_Invoice2_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class UBL21_Invoice2_Cell_local_selector : IQueryable<UBL21_Invoice2_Cell>, IOrderedQueryable<UBL21_Invoice2_Cell>
    {
        private         Expression                                   query_expression;
        private         UBL21_Invoice2_Cell_local_query_provider             query_provider;
        private UBL21_Invoice2_Cell_local_selector() { /* nobody should reach this method */ }
        internal UBL21_Invoice2_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new UBL21_Invoice2_Cell_local_query_provider(storage, tx);
        }
        internal unsafe UBL21_Invoice2_Cell_local_selector(UBL21_Invoice2_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<UBL21_Invoice2_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<UBL21_Invoice2_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<UBL21_Invoice2_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(UBL21_Invoice2_Cell); }
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
        /// Enumerates all the TRACredential_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRACredential_Cell within the local memory storage.</returns>
        public static TRACredential_Cell_local_selector TRACredential_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new TRACredential_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TRACredential_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRACredential_Cell_Accessor within the local memory storage.</returns>
        public static TRACredential_Cell_Accessor_local_selector TRACredential_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TRACredential_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TRACredential_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRACredential_Cell within the local memory storage.</returns>
        public static TRACredential_Cell_local_selector TRACredential_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TRACredential_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TRACredential_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRACredential_Cell_Accessor within the local memory storage.</returns>
        public static TRACredential_Cell_Accessor_local_selector TRACredential_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TRACredential_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the TRATimestamp_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRATimestamp_Cell within the local memory storage.</returns>
        public static TRATimestamp_Cell_local_selector TRATimestamp_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new TRATimestamp_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TRATimestamp_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRATimestamp_Cell_Accessor within the local memory storage.</returns>
        public static TRATimestamp_Cell_Accessor_local_selector TRATimestamp_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TRATimestamp_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TRATimestamp_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRATimestamp_Cell within the local memory storage.</returns>
        public static TRATimestamp_Cell_local_selector TRATimestamp_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TRATimestamp_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TRATimestamp_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRATimestamp_Cell_Accessor within the local memory storage.</returns>
        public static TRATimestamp_Cell_Accessor_local_selector TRATimestamp_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TRATimestamp_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the TDWGeoLocation_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWGeoLocation_Cell within the local memory storage.</returns>
        public static TDWGeoLocation_Cell_local_selector TDWGeoLocation_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new TDWGeoLocation_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWGeoLocation_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWGeoLocation_Cell_Accessor within the local memory storage.</returns>
        public static TDWGeoLocation_Cell_Accessor_local_selector TDWGeoLocation_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TDWGeoLocation_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWGeoLocation_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWGeoLocation_Cell within the local memory storage.</returns>
        public static TDWGeoLocation_Cell_local_selector TDWGeoLocation_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWGeoLocation_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TDWGeoLocation_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWGeoLocation_Cell_Accessor within the local memory storage.</returns>
        public static TDWGeoLocation_Cell_Accessor_local_selector TDWGeoLocation_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWGeoLocation_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the TRAPostalAddress_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRAPostalAddress_Cell within the local memory storage.</returns>
        public static TRAPostalAddress_Cell_local_selector TRAPostalAddress_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new TRAPostalAddress_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TRAPostalAddress_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRAPostalAddress_Cell_Accessor within the local memory storage.</returns>
        public static TRAPostalAddress_Cell_Accessor_local_selector TRAPostalAddress_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TRAPostalAddress_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TRAPostalAddress_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRAPostalAddress_Cell within the local memory storage.</returns>
        public static TRAPostalAddress_Cell_local_selector TRAPostalAddress_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TRAPostalAddress_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TRAPostalAddress_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRAPostalAddress_Cell_Accessor within the local memory storage.</returns>
        public static TRAPostalAddress_Cell_Accessor_local_selector TRAPostalAddress_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TRAPostalAddress_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the Cac_Item_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Item_Cell within the local memory storage.</returns>
        public static Cac_Item_Cell_local_selector Cac_Item_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_Item_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_Item_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Item_Cell_Accessor within the local memory storage.</returns>
        public static Cac_Item_Cell_Accessor_local_selector Cac_Item_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_Item_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_Item_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Item_Cell within the local memory storage.</returns>
        public static Cac_Item_Cell_local_selector Cac_Item_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_Item_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the Cac_Item_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Item_Cell_Accessor within the local memory storage.</returns>
        public static Cac_Item_Cell_Accessor_local_selector Cac_Item_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_Item_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the Cac_ExternalReference_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_ExternalReference_Cell within the local memory storage.</returns>
        public static Cac_ExternalReference_Cell_local_selector Cac_ExternalReference_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_ExternalReference_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_ExternalReference_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_ExternalReference_Cell_Accessor within the local memory storage.</returns>
        public static Cac_ExternalReference_Cell_Accessor_local_selector Cac_ExternalReference_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_ExternalReference_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_ExternalReference_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_ExternalReference_Cell within the local memory storage.</returns>
        public static Cac_ExternalReference_Cell_local_selector Cac_ExternalReference_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_ExternalReference_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the Cac_ExternalReference_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_ExternalReference_Cell_Accessor within the local memory storage.</returns>
        public static Cac_ExternalReference_Cell_Accessor_local_selector Cac_ExternalReference_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_ExternalReference_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the Cac_Address_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Address_Cell within the local memory storage.</returns>
        public static Cac_Address_Cell_local_selector Cac_Address_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_Address_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_Address_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Address_Cell_Accessor within the local memory storage.</returns>
        public static Cac_Address_Cell_Accessor_local_selector Cac_Address_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_Address_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_Address_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Address_Cell within the local memory storage.</returns>
        public static Cac_Address_Cell_local_selector Cac_Address_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_Address_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the Cac_Address_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Address_Cell_Accessor within the local memory storage.</returns>
        public static Cac_Address_Cell_Accessor_local_selector Cac_Address_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_Address_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the Cac_PostalAddress_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PostalAddress_Cell within the local memory storage.</returns>
        public static Cac_PostalAddress_Cell_local_selector Cac_PostalAddress_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_PostalAddress_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_PostalAddress_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PostalAddress_Cell_Accessor within the local memory storage.</returns>
        public static Cac_PostalAddress_Cell_Accessor_local_selector Cac_PostalAddress_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_PostalAddress_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_PostalAddress_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PostalAddress_Cell within the local memory storage.</returns>
        public static Cac_PostalAddress_Cell_local_selector Cac_PostalAddress_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_PostalAddress_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the Cac_PostalAddress_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PostalAddress_Cell_Accessor within the local memory storage.</returns>
        public static Cac_PostalAddress_Cell_Accessor_local_selector Cac_PostalAddress_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_PostalAddress_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the Cac_PartyLegalEntity_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PartyLegalEntity_Cell within the local memory storage.</returns>
        public static Cac_PartyLegalEntity_Cell_local_selector Cac_PartyLegalEntity_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_PartyLegalEntity_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_PartyLegalEntity_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PartyLegalEntity_Cell_Accessor within the local memory storage.</returns>
        public static Cac_PartyLegalEntity_Cell_Accessor_local_selector Cac_PartyLegalEntity_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_PartyLegalEntity_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_PartyLegalEntity_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PartyLegalEntity_Cell within the local memory storage.</returns>
        public static Cac_PartyLegalEntity_Cell_local_selector Cac_PartyLegalEntity_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_PartyLegalEntity_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the Cac_PartyLegalEntity_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PartyLegalEntity_Cell_Accessor within the local memory storage.</returns>
        public static Cac_PartyLegalEntity_Cell_Accessor_local_selector Cac_PartyLegalEntity_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_PartyLegalEntity_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the Cac_Contact_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Contact_Cell within the local memory storage.</returns>
        public static Cac_Contact_Cell_local_selector Cac_Contact_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_Contact_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_Contact_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Contact_Cell_Accessor within the local memory storage.</returns>
        public static Cac_Contact_Cell_Accessor_local_selector Cac_Contact_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_Contact_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_Contact_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Contact_Cell within the local memory storage.</returns>
        public static Cac_Contact_Cell_local_selector Cac_Contact_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_Contact_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the Cac_Contact_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Contact_Cell_Accessor within the local memory storage.</returns>
        public static Cac_Contact_Cell_Accessor_local_selector Cac_Contact_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_Contact_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the Cac_Person_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Person_Cell within the local memory storage.</returns>
        public static Cac_Person_Cell_local_selector Cac_Person_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_Person_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_Person_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Person_Cell_Accessor within the local memory storage.</returns>
        public static Cac_Person_Cell_Accessor_local_selector Cac_Person_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_Person_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_Person_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Person_Cell within the local memory storage.</returns>
        public static Cac_Person_Cell_local_selector Cac_Person_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_Person_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the Cac_Person_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Person_Cell_Accessor within the local memory storage.</returns>
        public static Cac_Person_Cell_Accessor_local_selector Cac_Person_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_Person_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the Cac_PaymentMeans_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PaymentMeans_Cell within the local memory storage.</returns>
        public static Cac_PaymentMeans_Cell_local_selector Cac_PaymentMeans_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_PaymentMeans_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_PaymentMeans_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PaymentMeans_Cell_Accessor within the local memory storage.</returns>
        public static Cac_PaymentMeans_Cell_Accessor_local_selector Cac_PaymentMeans_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_PaymentMeans_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_PaymentMeans_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PaymentMeans_Cell within the local memory storage.</returns>
        public static Cac_PaymentMeans_Cell_local_selector Cac_PaymentMeans_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_PaymentMeans_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the Cac_PaymentMeans_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PaymentMeans_Cell_Accessor within the local memory storage.</returns>
        public static Cac_PaymentMeans_Cell_Accessor_local_selector Cac_PaymentMeans_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_PaymentMeans_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the Cac_PayeeFinancialAccount_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PayeeFinancialAccount_Cell within the local memory storage.</returns>
        public static Cac_PayeeFinancialAccount_Cell_local_selector Cac_PayeeFinancialAccount_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_PayeeFinancialAccount_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_PayeeFinancialAccount_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PayeeFinancialAccount_Cell_Accessor within the local memory storage.</returns>
        public static Cac_PayeeFinancialAccount_Cell_Accessor_local_selector Cac_PayeeFinancialAccount_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_PayeeFinancialAccount_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_PayeeFinancialAccount_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PayeeFinancialAccount_Cell within the local memory storage.</returns>
        public static Cac_PayeeFinancialAccount_Cell_local_selector Cac_PayeeFinancialAccount_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_PayeeFinancialAccount_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the Cac_PayeeFinancialAccount_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_PayeeFinancialAccount_Cell_Accessor within the local memory storage.</returns>
        public static Cac_PayeeFinancialAccount_Cell_Accessor_local_selector Cac_PayeeFinancialAccount_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_PayeeFinancialAccount_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the Cac_Party_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Party_Cell within the local memory storage.</returns>
        public static Cac_Party_Cell_local_selector Cac_Party_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_Party_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_Party_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Party_Cell_Accessor within the local memory storage.</returns>
        public static Cac_Party_Cell_Accessor_local_selector Cac_Party_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new Cac_Party_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the Cac_Party_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Party_Cell within the local memory storage.</returns>
        public static Cac_Party_Cell_local_selector Cac_Party_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_Party_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the Cac_Party_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the Cac_Party_Cell_Accessor within the local memory storage.</returns>
        public static Cac_Party_Cell_Accessor_local_selector Cac_Party_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new Cac_Party_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the UBL21_Invoice2_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the UBL21_Invoice2_Cell within the local memory storage.</returns>
        public static UBL21_Invoice2_Cell_local_selector UBL21_Invoice2_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new UBL21_Invoice2_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the UBL21_Invoice2_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the UBL21_Invoice2_Cell_Accessor within the local memory storage.</returns>
        public static UBL21_Invoice2_Cell_Accessor_local_selector UBL21_Invoice2_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new UBL21_Invoice2_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the UBL21_Invoice2_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the UBL21_Invoice2_Cell within the local memory storage.</returns>
        public static UBL21_Invoice2_Cell_local_selector UBL21_Invoice2_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new UBL21_Invoice2_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the UBL21_Invoice2_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the UBL21_Invoice2_Cell_Accessor within the local memory storage.</returns>
        public static UBL21_Invoice2_Cell_Accessor_local_selector UBL21_Invoice2_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new UBL21_Invoice2_Cell_Accessor_local_selector(storage, tx);
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522

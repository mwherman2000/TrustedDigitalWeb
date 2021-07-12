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
     * Accepts transformation from TRACredentialCell_Accessor to T.
     * </summary>
     */
    internal class TRACredentialCell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TRACredentialCell_Accessor_local_query_provider    query_provider;
        internal TRACredentialCell_Accessor_local_projector(TRACredentialCell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TRACredentialCell to T.
     */
    internal class TRACredentialCell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TRACredentialCell_local_query_provider             query_provider;
        internal TRACredentialCell_local_projector(TRACredentialCell_local_query_provider provider, Expression expression)
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
    internal class TRACredentialCell_AccessorEnumerable : IEnumerable<TRACredentialCell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TRACredentialCell_Accessor,bool> m_filter_predicate;
        internal TRACredentialCell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TRACredentialCell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRACredentialCell)
                        {
                            var accessor = TRACredentialCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRACredentialCell)
                        {
                            var accessor = TRACredentialCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTRACredentialCell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTRACredentialCell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TRACredentialCell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TRACredentialCell_Enumerable : IEnumerable<TRACredentialCell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TRACredentialCell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TRACredentialCell);
        private LocalTransactionContext m_tx;
        internal TRACredentialCell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TRACredentialCell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRACredentialCell)
                        {
                            var accessor = TRACredentialCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRACredentialCell)
                        {
                            var accessor = TRACredentialCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTRACredentialCell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTRACredentialCell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TRACredentialCell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TRACredentialCell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TRACredentialCell_Accessor);
        private static  Type                             s_cell_type        = typeof(TRACredentialCell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TRACredentialCell_AccessorEnumerable   m_accessor_enumerable;
        internal TRACredentialCell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TRACredentialCell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TRACredentialCell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TRACredentialCell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TRACredentialCell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TRACredentialCell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TRACredentialCell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TRACredentialCell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TRACredentialCell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TRACredentialCell_Accessor>("TRACredentialCell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TRACredentialCell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TRACredentialCell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TRACredentialCell_Enumerable           s_cell_enumerable;
        internal TRACredentialCell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TRACredentialCell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TRACredentialCell_local_selector(this, expression);
            }
            else
            {
                return new TRACredentialCell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TRACredentialCell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TRACredentialCell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TRACredentialCell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TRACredentialCell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TRACredentialCell> query_tree_gen       = new IndexQueryTreeGenerator<TRACredentialCell>("TRACredentialCell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TRACredentialCell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TRACredentialCell_Accessor_local_selector : IQueryable<TRACredentialCell_Accessor>
    {
        private         Expression                                   query_expression;
        private         TRACredentialCell_Accessor_local_query_provider    query_provider;
        private TRACredentialCell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TRACredentialCell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TRACredentialCell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TRACredentialCell_Accessor_local_selector(TRACredentialCell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TRACredentialCell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TRACredentialCell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TRACredentialCell_Accessor); }
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
        public PLINQWrapper<TRACredentialCell_Accessor> AsParallel()
        {
            return new PLINQWrapper<TRACredentialCell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TRACredentialCell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TRACredentialCell_local_selector : IQueryable<TRACredentialCell>, IOrderedQueryable<TRACredentialCell>
    {
        private         Expression                                   query_expression;
        private         TRACredentialCell_local_query_provider             query_provider;
        private TRACredentialCell_local_selector() { /* nobody should reach this method */ }
        internal TRACredentialCell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TRACredentialCell_local_query_provider(storage, tx);
        }
        internal unsafe TRACredentialCell_local_selector(TRACredentialCell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TRACredentialCell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TRACredentialCell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TRACredentialCell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TRACredentialCell); }
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
     * Accepts transformation from TRATimestampCell_Accessor to T.
     * </summary>
     */
    internal class TRATimestampCell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TRATimestampCell_Accessor_local_query_provider    query_provider;
        internal TRATimestampCell_Accessor_local_projector(TRATimestampCell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TRATimestampCell to T.
     */
    internal class TRATimestampCell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TRATimestampCell_local_query_provider             query_provider;
        internal TRATimestampCell_local_projector(TRATimestampCell_local_query_provider provider, Expression expression)
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
    internal class TRATimestampCell_AccessorEnumerable : IEnumerable<TRATimestampCell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TRATimestampCell_Accessor,bool> m_filter_predicate;
        internal TRATimestampCell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TRATimestampCell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRATimestampCell)
                        {
                            var accessor = TRATimestampCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRATimestampCell)
                        {
                            var accessor = TRATimestampCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTRATimestampCell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTRATimestampCell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TRATimestampCell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TRATimestampCell_Enumerable : IEnumerable<TRATimestampCell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TRATimestampCell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TRATimestampCell);
        private LocalTransactionContext m_tx;
        internal TRATimestampCell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TRATimestampCell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRATimestampCell)
                        {
                            var accessor = TRATimestampCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRATimestampCell)
                        {
                            var accessor = TRATimestampCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTRATimestampCell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTRATimestampCell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TRATimestampCell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TRATimestampCell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TRATimestampCell_Accessor);
        private static  Type                             s_cell_type        = typeof(TRATimestampCell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TRATimestampCell_AccessorEnumerable   m_accessor_enumerable;
        internal TRATimestampCell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TRATimestampCell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TRATimestampCell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TRATimestampCell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TRATimestampCell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TRATimestampCell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TRATimestampCell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TRATimestampCell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TRATimestampCell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TRATimestampCell_Accessor>("TRATimestampCell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TRATimestampCell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TRATimestampCell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TRATimestampCell_Enumerable           s_cell_enumerable;
        internal TRATimestampCell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TRATimestampCell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TRATimestampCell_local_selector(this, expression);
            }
            else
            {
                return new TRATimestampCell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TRATimestampCell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TRATimestampCell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TRATimestampCell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TRATimestampCell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TRATimestampCell> query_tree_gen       = new IndexQueryTreeGenerator<TRATimestampCell>("TRATimestampCell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TRATimestampCell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TRATimestampCell_Accessor_local_selector : IQueryable<TRATimestampCell_Accessor>
    {
        private         Expression                                   query_expression;
        private         TRATimestampCell_Accessor_local_query_provider    query_provider;
        private TRATimestampCell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TRATimestampCell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TRATimestampCell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TRATimestampCell_Accessor_local_selector(TRATimestampCell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TRATimestampCell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TRATimestampCell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TRATimestampCell_Accessor); }
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
        public PLINQWrapper<TRATimestampCell_Accessor> AsParallel()
        {
            return new PLINQWrapper<TRATimestampCell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TRATimestampCell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TRATimestampCell_local_selector : IQueryable<TRATimestampCell>, IOrderedQueryable<TRATimestampCell>
    {
        private         Expression                                   query_expression;
        private         TRATimestampCell_local_query_provider             query_provider;
        private TRATimestampCell_local_selector() { /* nobody should reach this method */ }
        internal TRATimestampCell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TRATimestampCell_local_query_provider(storage, tx);
        }
        internal unsafe TRATimestampCell_local_selector(TRATimestampCell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TRATimestampCell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TRATimestampCell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TRATimestampCell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TRATimestampCell); }
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
     * Accepts transformation from TDWGeoLocationCell_Accessor to T.
     * </summary>
     */
    internal class TDWGeoLocationCell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWGeoLocationCell_Accessor_local_query_provider    query_provider;
        internal TDWGeoLocationCell_Accessor_local_projector(TDWGeoLocationCell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TDWGeoLocationCell to T.
     */
    internal class TDWGeoLocationCell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWGeoLocationCell_local_query_provider             query_provider;
        internal TDWGeoLocationCell_local_projector(TDWGeoLocationCell_local_query_provider provider, Expression expression)
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
    internal class TDWGeoLocationCell_AccessorEnumerable : IEnumerable<TDWGeoLocationCell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TDWGeoLocationCell_Accessor,bool> m_filter_predicate;
        internal TDWGeoLocationCell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWGeoLocationCell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWGeoLocationCell)
                        {
                            var accessor = TDWGeoLocationCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWGeoLocationCell)
                        {
                            var accessor = TDWGeoLocationCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWGeoLocationCell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWGeoLocationCell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWGeoLocationCell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWGeoLocationCell_Enumerable : IEnumerable<TDWGeoLocationCell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TDWGeoLocationCell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TDWGeoLocationCell);
        private LocalTransactionContext m_tx;
        internal TDWGeoLocationCell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWGeoLocationCell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWGeoLocationCell)
                        {
                            var accessor = TDWGeoLocationCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWGeoLocationCell)
                        {
                            var accessor = TDWGeoLocationCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWGeoLocationCell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWGeoLocationCell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWGeoLocationCell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWGeoLocationCell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TDWGeoLocationCell_Accessor);
        private static  Type                             s_cell_type        = typeof(TDWGeoLocationCell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWGeoLocationCell_AccessorEnumerable   m_accessor_enumerable;
        internal TDWGeoLocationCell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TDWGeoLocationCell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TDWGeoLocationCell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TDWGeoLocationCell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWGeoLocationCell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TDWGeoLocationCell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWGeoLocationCell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWGeoLocationCell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWGeoLocationCell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TDWGeoLocationCell_Accessor>("TDWGeoLocationCell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TDWGeoLocationCell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TDWGeoLocationCell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWGeoLocationCell_Enumerable           s_cell_enumerable;
        internal TDWGeoLocationCell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TDWGeoLocationCell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TDWGeoLocationCell_local_selector(this, expression);
            }
            else
            {
                return new TDWGeoLocationCell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWGeoLocationCell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TDWGeoLocationCell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWGeoLocationCell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWGeoLocationCell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWGeoLocationCell> query_tree_gen       = new IndexQueryTreeGenerator<TDWGeoLocationCell>("TDWGeoLocationCell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TDWGeoLocationCell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWGeoLocationCell_Accessor_local_selector : IQueryable<TDWGeoLocationCell_Accessor>
    {
        private         Expression                                   query_expression;
        private         TDWGeoLocationCell_Accessor_local_query_provider    query_provider;
        private TDWGeoLocationCell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TDWGeoLocationCell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWGeoLocationCell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TDWGeoLocationCell_Accessor_local_selector(TDWGeoLocationCell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TDWGeoLocationCell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWGeoLocationCell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWGeoLocationCell_Accessor); }
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
        public PLINQWrapper<TDWGeoLocationCell_Accessor> AsParallel()
        {
            return new PLINQWrapper<TDWGeoLocationCell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TDWGeoLocationCell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWGeoLocationCell_local_selector : IQueryable<TDWGeoLocationCell>, IOrderedQueryable<TDWGeoLocationCell>
    {
        private         Expression                                   query_expression;
        private         TDWGeoLocationCell_local_query_provider             query_provider;
        private TDWGeoLocationCell_local_selector() { /* nobody should reach this method */ }
        internal TDWGeoLocationCell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWGeoLocationCell_local_query_provider(storage, tx);
        }
        internal unsafe TDWGeoLocationCell_local_selector(TDWGeoLocationCell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TDWGeoLocationCell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWGeoLocationCell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TDWGeoLocationCell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWGeoLocationCell); }
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
     * Accepts transformation from TRAPostalAddressCell_Accessor to T.
     * </summary>
     */
    internal class TRAPostalAddressCell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TRAPostalAddressCell_Accessor_local_query_provider    query_provider;
        internal TRAPostalAddressCell_Accessor_local_projector(TRAPostalAddressCell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TRAPostalAddressCell to T.
     */
    internal class TRAPostalAddressCell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TRAPostalAddressCell_local_query_provider             query_provider;
        internal TRAPostalAddressCell_local_projector(TRAPostalAddressCell_local_query_provider provider, Expression expression)
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
    internal class TRAPostalAddressCell_AccessorEnumerable : IEnumerable<TRAPostalAddressCell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TRAPostalAddressCell_Accessor,bool> m_filter_predicate;
        internal TRAPostalAddressCell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TRAPostalAddressCell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRAPostalAddressCell)
                        {
                            var accessor = TRAPostalAddressCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRAPostalAddressCell)
                        {
                            var accessor = TRAPostalAddressCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTRAPostalAddressCell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTRAPostalAddressCell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TRAPostalAddressCell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TRAPostalAddressCell_Enumerable : IEnumerable<TRAPostalAddressCell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TRAPostalAddressCell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TRAPostalAddressCell);
        private LocalTransactionContext m_tx;
        internal TRAPostalAddressCell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TRAPostalAddressCell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRAPostalAddressCell)
                        {
                            var accessor = TRAPostalAddressCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TRAPostalAddressCell)
                        {
                            var accessor = TRAPostalAddressCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTRAPostalAddressCell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTRAPostalAddressCell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TRAPostalAddressCell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TRAPostalAddressCell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TRAPostalAddressCell_Accessor);
        private static  Type                             s_cell_type        = typeof(TRAPostalAddressCell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TRAPostalAddressCell_AccessorEnumerable   m_accessor_enumerable;
        internal TRAPostalAddressCell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TRAPostalAddressCell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TRAPostalAddressCell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TRAPostalAddressCell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TRAPostalAddressCell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TRAPostalAddressCell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TRAPostalAddressCell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TRAPostalAddressCell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TRAPostalAddressCell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TRAPostalAddressCell_Accessor>("TRAPostalAddressCell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TRAPostalAddressCell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TRAPostalAddressCell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TRAPostalAddressCell_Enumerable           s_cell_enumerable;
        internal TRAPostalAddressCell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TRAPostalAddressCell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TRAPostalAddressCell_local_selector(this, expression);
            }
            else
            {
                return new TRAPostalAddressCell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TRAPostalAddressCell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TRAPostalAddressCell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TRAPostalAddressCell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TRAPostalAddressCell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TRAPostalAddressCell> query_tree_gen       = new IndexQueryTreeGenerator<TRAPostalAddressCell>("TRAPostalAddressCell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TRAPostalAddressCell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TRAPostalAddressCell_Accessor_local_selector : IQueryable<TRAPostalAddressCell_Accessor>
    {
        private         Expression                                   query_expression;
        private         TRAPostalAddressCell_Accessor_local_query_provider    query_provider;
        private TRAPostalAddressCell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TRAPostalAddressCell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TRAPostalAddressCell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TRAPostalAddressCell_Accessor_local_selector(TRAPostalAddressCell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TRAPostalAddressCell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TRAPostalAddressCell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TRAPostalAddressCell_Accessor); }
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
        public PLINQWrapper<TRAPostalAddressCell_Accessor> AsParallel()
        {
            return new PLINQWrapper<TRAPostalAddressCell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TRAPostalAddressCell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TRAPostalAddressCell_local_selector : IQueryable<TRAPostalAddressCell>, IOrderedQueryable<TRAPostalAddressCell>
    {
        private         Expression                                   query_expression;
        private         TRAPostalAddressCell_local_query_provider             query_provider;
        private TRAPostalAddressCell_local_selector() { /* nobody should reach this method */ }
        internal TRAPostalAddressCell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TRAPostalAddressCell_local_query_provider(storage, tx);
        }
        internal unsafe TRAPostalAddressCell_local_selector(TRAPostalAddressCell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TRAPostalAddressCell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TRAPostalAddressCell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TRAPostalAddressCell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TRAPostalAddressCell); }
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
        /// Enumerates all the TRACredentialCell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRACredentialCell within the local memory storage.</returns>
        public static TRACredentialCell_local_selector TRACredentialCell_Selector(this LocalMemoryStorage storage)
        {
            return new TRACredentialCell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TRACredentialCell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRACredentialCell_Accessor within the local memory storage.</returns>
        public static TRACredentialCell_Accessor_local_selector TRACredentialCell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TRACredentialCell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TRACredentialCell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRACredentialCell within the local memory storage.</returns>
        public static TRACredentialCell_local_selector TRACredentialCell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TRACredentialCell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TRACredentialCell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRACredentialCell_Accessor within the local memory storage.</returns>
        public static TRACredentialCell_Accessor_local_selector TRACredentialCell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TRACredentialCell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the TRATimestampCell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRATimestampCell within the local memory storage.</returns>
        public static TRATimestampCell_local_selector TRATimestampCell_Selector(this LocalMemoryStorage storage)
        {
            return new TRATimestampCell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TRATimestampCell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRATimestampCell_Accessor within the local memory storage.</returns>
        public static TRATimestampCell_Accessor_local_selector TRATimestampCell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TRATimestampCell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TRATimestampCell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRATimestampCell within the local memory storage.</returns>
        public static TRATimestampCell_local_selector TRATimestampCell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TRATimestampCell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TRATimestampCell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRATimestampCell_Accessor within the local memory storage.</returns>
        public static TRATimestampCell_Accessor_local_selector TRATimestampCell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TRATimestampCell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the TDWGeoLocationCell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWGeoLocationCell within the local memory storage.</returns>
        public static TDWGeoLocationCell_local_selector TDWGeoLocationCell_Selector(this LocalMemoryStorage storage)
        {
            return new TDWGeoLocationCell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWGeoLocationCell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWGeoLocationCell_Accessor within the local memory storage.</returns>
        public static TDWGeoLocationCell_Accessor_local_selector TDWGeoLocationCell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TDWGeoLocationCell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWGeoLocationCell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWGeoLocationCell within the local memory storage.</returns>
        public static TDWGeoLocationCell_local_selector TDWGeoLocationCell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWGeoLocationCell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TDWGeoLocationCell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWGeoLocationCell_Accessor within the local memory storage.</returns>
        public static TDWGeoLocationCell_Accessor_local_selector TDWGeoLocationCell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWGeoLocationCell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the TRAPostalAddressCell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRAPostalAddressCell within the local memory storage.</returns>
        public static TRAPostalAddressCell_local_selector TRAPostalAddressCell_Selector(this LocalMemoryStorage storage)
        {
            return new TRAPostalAddressCell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TRAPostalAddressCell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRAPostalAddressCell_Accessor within the local memory storage.</returns>
        public static TRAPostalAddressCell_Accessor_local_selector TRAPostalAddressCell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TRAPostalAddressCell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TRAPostalAddressCell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRAPostalAddressCell within the local memory storage.</returns>
        public static TRAPostalAddressCell_local_selector TRAPostalAddressCell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TRAPostalAddressCell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TRAPostalAddressCell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TRAPostalAddressCell_Accessor within the local memory storage.</returns>
        public static TRAPostalAddressCell_Accessor_local_selector TRAPostalAddressCell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TRAPostalAddressCell_Accessor_local_selector(storage, tx);
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522

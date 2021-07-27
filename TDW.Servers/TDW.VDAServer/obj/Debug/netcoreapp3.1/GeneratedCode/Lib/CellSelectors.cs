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
     * Accepts transformation from TDWVDAAccountEntry_Cell_Accessor to T.
     * </summary>
     */
    internal class TDWVDAAccountEntry_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWVDAAccountEntry_Cell_Accessor_local_query_provider    query_provider;
        internal TDWVDAAccountEntry_Cell_Accessor_local_projector(TDWVDAAccountEntry_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TDWVDAAccountEntry_Cell to T.
     */
    internal class TDWVDAAccountEntry_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWVDAAccountEntry_Cell_local_query_provider             query_provider;
        internal TDWVDAAccountEntry_Cell_local_projector(TDWVDAAccountEntry_Cell_local_query_provider provider, Expression expression)
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
    internal class TDWVDAAccountEntry_Cell_AccessorEnumerable : IEnumerable<TDWVDAAccountEntry_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TDWVDAAccountEntry_Cell_Accessor,bool> m_filter_predicate;
        internal TDWVDAAccountEntry_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWVDAAccountEntry_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDAAccountEntry_Cell)
                        {
                            var accessor = TDWVDAAccountEntry_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDAAccountEntry_Cell)
                        {
                            var accessor = TDWVDAAccountEntry_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWVDAAccountEntry_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWVDAAccountEntry_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWVDAAccountEntry_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWVDAAccountEntry_Cell_Enumerable : IEnumerable<TDWVDAAccountEntry_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TDWVDAAccountEntry_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TDWVDAAccountEntry_Cell);
        private LocalTransactionContext m_tx;
        internal TDWVDAAccountEntry_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWVDAAccountEntry_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDAAccountEntry_Cell)
                        {
                            var accessor = TDWVDAAccountEntry_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDAAccountEntry_Cell)
                        {
                            var accessor = TDWVDAAccountEntry_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWVDAAccountEntry_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWVDAAccountEntry_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWVDAAccountEntry_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWVDAAccountEntry_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TDWVDAAccountEntry_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(TDWVDAAccountEntry_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWVDAAccountEntry_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal TDWVDAAccountEntry_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TDWVDAAccountEntry_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TDWVDAAccountEntry_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TDWVDAAccountEntry_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWVDAAccountEntry_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TDWVDAAccountEntry_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWVDAAccountEntry_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWVDAAccountEntry_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWVDAAccountEntry_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TDWVDAAccountEntry_Cell_Accessor>("TDWVDAAccountEntry_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TDWVDAAccountEntry_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TDWVDAAccountEntry_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWVDAAccountEntry_Cell_Enumerable           s_cell_enumerable;
        internal TDWVDAAccountEntry_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TDWVDAAccountEntry_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TDWVDAAccountEntry_Cell_local_selector(this, expression);
            }
            else
            {
                return new TDWVDAAccountEntry_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWVDAAccountEntry_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TDWVDAAccountEntry_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWVDAAccountEntry_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWVDAAccountEntry_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWVDAAccountEntry_Cell> query_tree_gen       = new IndexQueryTreeGenerator<TDWVDAAccountEntry_Cell>("TDWVDAAccountEntry_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TDWVDAAccountEntry_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWVDAAccountEntry_Cell_Accessor_local_selector : IQueryable<TDWVDAAccountEntry_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         TDWVDAAccountEntry_Cell_Accessor_local_query_provider    query_provider;
        private TDWVDAAccountEntry_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TDWVDAAccountEntry_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWVDAAccountEntry_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TDWVDAAccountEntry_Cell_Accessor_local_selector(TDWVDAAccountEntry_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TDWVDAAccountEntry_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWVDAAccountEntry_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWVDAAccountEntry_Cell_Accessor); }
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
        public PLINQWrapper<TDWVDAAccountEntry_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<TDWVDAAccountEntry_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TDWVDAAccountEntry_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWVDAAccountEntry_Cell_local_selector : IQueryable<TDWVDAAccountEntry_Cell>, IOrderedQueryable<TDWVDAAccountEntry_Cell>
    {
        private         Expression                                   query_expression;
        private         TDWVDAAccountEntry_Cell_local_query_provider             query_provider;
        private TDWVDAAccountEntry_Cell_local_selector() { /* nobody should reach this method */ }
        internal TDWVDAAccountEntry_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWVDAAccountEntry_Cell_local_query_provider(storage, tx);
        }
        internal unsafe TDWVDAAccountEntry_Cell_local_selector(TDWVDAAccountEntry_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TDWVDAAccountEntry_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWVDAAccountEntry_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TDWVDAAccountEntry_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWVDAAccountEntry_Cell); }
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
     * Accepts transformation from TDWVDASmartContractEntry_Cell_Accessor to T.
     * </summary>
     */
    internal class TDWVDASmartContractEntry_Cell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWVDASmartContractEntry_Cell_Accessor_local_query_provider    query_provider;
        internal TDWVDASmartContractEntry_Cell_Accessor_local_projector(TDWVDASmartContractEntry_Cell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TDWVDASmartContractEntry_Cell to T.
     */
    internal class TDWVDASmartContractEntry_Cell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWVDASmartContractEntry_Cell_local_query_provider             query_provider;
        internal TDWVDASmartContractEntry_Cell_local_projector(TDWVDASmartContractEntry_Cell_local_query_provider provider, Expression expression)
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
    internal class TDWVDASmartContractEntry_Cell_AccessorEnumerable : IEnumerable<TDWVDASmartContractEntry_Cell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TDWVDASmartContractEntry_Cell_Accessor,bool> m_filter_predicate;
        internal TDWVDASmartContractEntry_Cell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWVDASmartContractEntry_Cell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDASmartContractEntry_Cell)
                        {
                            var accessor = TDWVDASmartContractEntry_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDASmartContractEntry_Cell)
                        {
                            var accessor = TDWVDASmartContractEntry_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWVDASmartContractEntry_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWVDASmartContractEntry_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWVDASmartContractEntry_Cell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWVDASmartContractEntry_Cell_Enumerable : IEnumerable<TDWVDASmartContractEntry_Cell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TDWVDASmartContractEntry_Cell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TDWVDASmartContractEntry_Cell);
        private LocalTransactionContext m_tx;
        internal TDWVDASmartContractEntry_Cell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWVDASmartContractEntry_Cell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDASmartContractEntry_Cell)
                        {
                            var accessor = TDWVDASmartContractEntry_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDASmartContractEntry_Cell)
                        {
                            var accessor = TDWVDASmartContractEntry_Cell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWVDASmartContractEntry_Cell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWVDASmartContractEntry_Cell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWVDASmartContractEntry_Cell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWVDASmartContractEntry_Cell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TDWVDASmartContractEntry_Cell_Accessor);
        private static  Type                             s_cell_type        = typeof(TDWVDASmartContractEntry_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWVDASmartContractEntry_Cell_AccessorEnumerable   m_accessor_enumerable;
        internal TDWVDASmartContractEntry_Cell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TDWVDASmartContractEntry_Cell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TDWVDASmartContractEntry_Cell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TDWVDASmartContractEntry_Cell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWVDASmartContractEntry_Cell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TDWVDASmartContractEntry_Cell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWVDASmartContractEntry_Cell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWVDASmartContractEntry_Cell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWVDASmartContractEntry_Cell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TDWVDASmartContractEntry_Cell_Accessor>("TDWVDASmartContractEntry_Cell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TDWVDASmartContractEntry_Cell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TDWVDASmartContractEntry_Cell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWVDASmartContractEntry_Cell_Enumerable           s_cell_enumerable;
        internal TDWVDASmartContractEntry_Cell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TDWVDASmartContractEntry_Cell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TDWVDASmartContractEntry_Cell_local_selector(this, expression);
            }
            else
            {
                return new TDWVDASmartContractEntry_Cell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWVDASmartContractEntry_Cell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TDWVDASmartContractEntry_Cell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWVDASmartContractEntry_Cell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWVDASmartContractEntry_Cell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWVDASmartContractEntry_Cell> query_tree_gen       = new IndexQueryTreeGenerator<TDWVDASmartContractEntry_Cell>("TDWVDASmartContractEntry_Cell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TDWVDASmartContractEntry_Cell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWVDASmartContractEntry_Cell_Accessor_local_selector : IQueryable<TDWVDASmartContractEntry_Cell_Accessor>
    {
        private         Expression                                   query_expression;
        private         TDWVDASmartContractEntry_Cell_Accessor_local_query_provider    query_provider;
        private TDWVDASmartContractEntry_Cell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TDWVDASmartContractEntry_Cell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWVDASmartContractEntry_Cell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TDWVDASmartContractEntry_Cell_Accessor_local_selector(TDWVDASmartContractEntry_Cell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TDWVDASmartContractEntry_Cell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWVDASmartContractEntry_Cell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWVDASmartContractEntry_Cell_Accessor); }
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
        public PLINQWrapper<TDWVDASmartContractEntry_Cell_Accessor> AsParallel()
        {
            return new PLINQWrapper<TDWVDASmartContractEntry_Cell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TDWVDASmartContractEntry_Cell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWVDASmartContractEntry_Cell_local_selector : IQueryable<TDWVDASmartContractEntry_Cell>, IOrderedQueryable<TDWVDASmartContractEntry_Cell>
    {
        private         Expression                                   query_expression;
        private         TDWVDASmartContractEntry_Cell_local_query_provider             query_provider;
        private TDWVDASmartContractEntry_Cell_local_selector() { /* nobody should reach this method */ }
        internal TDWVDASmartContractEntry_Cell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWVDASmartContractEntry_Cell_local_query_provider(storage, tx);
        }
        internal unsafe TDWVDASmartContractEntry_Cell_local_selector(TDWVDASmartContractEntry_Cell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TDWVDASmartContractEntry_Cell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWVDASmartContractEntry_Cell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TDWVDASmartContractEntry_Cell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWVDASmartContractEntry_Cell); }
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
        /// Enumerates all the TDWVDAAccountEntry_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDAAccountEntry_Cell within the local memory storage.</returns>
        public static TDWVDAAccountEntry_Cell_local_selector TDWVDAAccountEntry_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new TDWVDAAccountEntry_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWVDAAccountEntry_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDAAccountEntry_Cell_Accessor within the local memory storage.</returns>
        public static TDWVDAAccountEntry_Cell_Accessor_local_selector TDWVDAAccountEntry_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TDWVDAAccountEntry_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWVDAAccountEntry_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDAAccountEntry_Cell within the local memory storage.</returns>
        public static TDWVDAAccountEntry_Cell_local_selector TDWVDAAccountEntry_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWVDAAccountEntry_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TDWVDAAccountEntry_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDAAccountEntry_Cell_Accessor within the local memory storage.</returns>
        public static TDWVDAAccountEntry_Cell_Accessor_local_selector TDWVDAAccountEntry_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWVDAAccountEntry_Cell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the TDWVDASmartContractEntry_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDASmartContractEntry_Cell within the local memory storage.</returns>
        public static TDWVDASmartContractEntry_Cell_local_selector TDWVDASmartContractEntry_Cell_Selector(this LocalMemoryStorage storage)
        {
            return new TDWVDASmartContractEntry_Cell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWVDASmartContractEntry_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDASmartContractEntry_Cell_Accessor within the local memory storage.</returns>
        public static TDWVDASmartContractEntry_Cell_Accessor_local_selector TDWVDASmartContractEntry_Cell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TDWVDASmartContractEntry_Cell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWVDASmartContractEntry_Cell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDASmartContractEntry_Cell within the local memory storage.</returns>
        public static TDWVDASmartContractEntry_Cell_local_selector TDWVDASmartContractEntry_Cell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWVDASmartContractEntry_Cell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TDWVDASmartContractEntry_Cell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDASmartContractEntry_Cell_Accessor within the local memory storage.</returns>
        public static TDWVDASmartContractEntry_Cell_Accessor_local_selector TDWVDASmartContractEntry_Cell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWVDASmartContractEntry_Cell_Accessor_local_selector(storage, tx);
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522

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
     * Accepts transformation from TDWVDAAccountEntryCell_Accessor to T.
     * </summary>
     */
    internal class TDWVDAAccountEntryCell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWVDAAccountEntryCell_Accessor_local_query_provider    query_provider;
        internal TDWVDAAccountEntryCell_Accessor_local_projector(TDWVDAAccountEntryCell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TDWVDAAccountEntryCell to T.
     */
    internal class TDWVDAAccountEntryCell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWVDAAccountEntryCell_local_query_provider             query_provider;
        internal TDWVDAAccountEntryCell_local_projector(TDWVDAAccountEntryCell_local_query_provider provider, Expression expression)
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
    internal class TDWVDAAccountEntryCell_AccessorEnumerable : IEnumerable<TDWVDAAccountEntryCell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TDWVDAAccountEntryCell_Accessor,bool> m_filter_predicate;
        internal TDWVDAAccountEntryCell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWVDAAccountEntryCell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDAAccountEntryCell)
                        {
                            var accessor = TDWVDAAccountEntryCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDAAccountEntryCell)
                        {
                            var accessor = TDWVDAAccountEntryCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWVDAAccountEntryCell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWVDAAccountEntryCell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWVDAAccountEntryCell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWVDAAccountEntryCell_Enumerable : IEnumerable<TDWVDAAccountEntryCell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TDWVDAAccountEntryCell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TDWVDAAccountEntryCell);
        private LocalTransactionContext m_tx;
        internal TDWVDAAccountEntryCell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWVDAAccountEntryCell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDAAccountEntryCell)
                        {
                            var accessor = TDWVDAAccountEntryCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDAAccountEntryCell)
                        {
                            var accessor = TDWVDAAccountEntryCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWVDAAccountEntryCell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWVDAAccountEntryCell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWVDAAccountEntryCell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWVDAAccountEntryCell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TDWVDAAccountEntryCell_Accessor);
        private static  Type                             s_cell_type        = typeof(TDWVDAAccountEntryCell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWVDAAccountEntryCell_AccessorEnumerable   m_accessor_enumerable;
        internal TDWVDAAccountEntryCell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TDWVDAAccountEntryCell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TDWVDAAccountEntryCell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TDWVDAAccountEntryCell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWVDAAccountEntryCell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TDWVDAAccountEntryCell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWVDAAccountEntryCell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWVDAAccountEntryCell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWVDAAccountEntryCell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TDWVDAAccountEntryCell_Accessor>("TDWVDAAccountEntryCell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TDWVDAAccountEntryCell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TDWVDAAccountEntryCell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWVDAAccountEntryCell_Enumerable           s_cell_enumerable;
        internal TDWVDAAccountEntryCell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TDWVDAAccountEntryCell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TDWVDAAccountEntryCell_local_selector(this, expression);
            }
            else
            {
                return new TDWVDAAccountEntryCell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWVDAAccountEntryCell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TDWVDAAccountEntryCell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWVDAAccountEntryCell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWVDAAccountEntryCell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWVDAAccountEntryCell> query_tree_gen       = new IndexQueryTreeGenerator<TDWVDAAccountEntryCell>("TDWVDAAccountEntryCell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TDWVDAAccountEntryCell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWVDAAccountEntryCell_Accessor_local_selector : IQueryable<TDWVDAAccountEntryCell_Accessor>
    {
        private         Expression                                   query_expression;
        private         TDWVDAAccountEntryCell_Accessor_local_query_provider    query_provider;
        private TDWVDAAccountEntryCell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TDWVDAAccountEntryCell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWVDAAccountEntryCell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TDWVDAAccountEntryCell_Accessor_local_selector(TDWVDAAccountEntryCell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TDWVDAAccountEntryCell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWVDAAccountEntryCell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWVDAAccountEntryCell_Accessor); }
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
        public PLINQWrapper<TDWVDAAccountEntryCell_Accessor> AsParallel()
        {
            return new PLINQWrapper<TDWVDAAccountEntryCell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TDWVDAAccountEntryCell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWVDAAccountEntryCell_local_selector : IQueryable<TDWVDAAccountEntryCell>, IOrderedQueryable<TDWVDAAccountEntryCell>
    {
        private         Expression                                   query_expression;
        private         TDWVDAAccountEntryCell_local_query_provider             query_provider;
        private TDWVDAAccountEntryCell_local_selector() { /* nobody should reach this method */ }
        internal TDWVDAAccountEntryCell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWVDAAccountEntryCell_local_query_provider(storage, tx);
        }
        internal unsafe TDWVDAAccountEntryCell_local_selector(TDWVDAAccountEntryCell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TDWVDAAccountEntryCell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWVDAAccountEntryCell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TDWVDAAccountEntryCell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWVDAAccountEntryCell); }
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
     * Accepts transformation from TDWVDASmartContractEntryCell_Accessor to T.
     * </summary>
     */
    internal class TDWVDASmartContractEntryCell_Accessor_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWVDASmartContractEntryCell_Accessor_local_query_provider    query_provider;
        internal TDWVDASmartContractEntryCell_Accessor_local_projector(TDWVDASmartContractEntryCell_Accessor_local_query_provider provider, Expression expression)
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
     * Accepts transformation from TDWVDASmartContractEntryCell to T.
     */
    internal class TDWVDASmartContractEntryCell_local_projector<T> : IQueryable<T>
    {
        private         Expression                                   query_expression;
        private         TDWVDASmartContractEntryCell_local_query_provider             query_provider;
        internal TDWVDASmartContractEntryCell_local_projector(TDWVDASmartContractEntryCell_local_query_provider provider, Expression expression)
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
    internal class TDWVDASmartContractEntryCell_AccessorEnumerable : IEnumerable<TDWVDASmartContractEntryCell_Accessor>
    {
        private     LocalMemoryStorage              m_storage;
        private     LocalTransactionContext         m_tx;
        private     HashSet<long>                   m_filter_set;
        private     bool                            m_is_positive_filtering;
        private     Func<TDWVDASmartContractEntryCell_Accessor,bool> m_filter_predicate;
        internal TDWVDASmartContractEntryCell_AccessorEnumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWVDASmartContractEntryCell_Accessor> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDASmartContractEntryCell)
                        {
                            var accessor = TDWVDASmartContractEntryCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDASmartContractEntryCell)
                        {
                            var accessor = TDWVDASmartContractEntryCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWVDASmartContractEntryCell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWVDASmartContractEntryCell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWVDASmartContractEntryCell_Accessor, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWVDASmartContractEntryCell_Enumerable : IEnumerable<TDWVDASmartContractEntryCell>
    {
        private LocalMemoryStorage      m_storage;
        private HashSet<long>           m_filter_set;
        private bool                    m_is_positive_filtering;
        private Func<TDWVDASmartContractEntryCell,bool>  m_filter_predicate;
        private static Type             m_cell_type = typeof(TDWVDASmartContractEntryCell);
        private LocalTransactionContext m_tx;
        internal TDWVDASmartContractEntryCell_Enumerable(LocalMemoryStorage storage, LocalTransactionContext tx)
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
        public IEnumerator<TDWVDASmartContractEntryCell> GetEnumerator()
        {
            if (m_filter_set == null)
            {
                if (m_filter_predicate == null)
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDASmartContractEntryCell)
                        {
                            var accessor = TDWVDASmartContractEntryCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
                            yield return accessor;
                            accessor.Dispose();
                        }
                    }
                else
                    foreach (var cellInfo in m_storage)
                    {
                        if (cellInfo.CellType == (ushort)CellType.TDWVDASmartContractEntryCell)
                        {
                            var accessor = TDWVDASmartContractEntryCell_Accessor.AllocIterativeAccessor(cellInfo, m_tx);
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
                        using (var accessor = m_storage.UseTDWVDASmartContractEntryCell(cellID))
                        {
                            yield return accessor;
                        }
                    }
                else
                    foreach (var cellID in m_filter_set)
                    {
                        using (var accessor = m_storage.UseTDWVDASmartContractEntryCell(cellID))
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
            m_filter_predicate = Expression.Lambda<Func<TDWVDASmartContractEntryCell, bool>>(
                aggregated_where_clause,
                parameter
                ).Compile();
        }
    }
    internal class TDWVDASmartContractEntryCell_Accessor_local_query_provider : IQueryProvider
    {
        private static  Type                             s_accessor_type    = typeof(TDWVDASmartContractEntryCell_Accessor);
        private static  Type                             s_cell_type        = typeof(TDWVDASmartContractEntryCell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWVDASmartContractEntryCell_AccessorEnumerable   m_accessor_enumerable;
        internal TDWVDASmartContractEntryCell_Accessor_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            m_accessor_enumerable = new TDWVDASmartContractEntryCell_AccessorEnumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_accessor_type)
            {
                return (IQueryable<TElement>)new TDWVDASmartContractEntryCell_Accessor_local_selector(this, expression);
            }
            else
            {
                return new TDWVDASmartContractEntryCell_Accessor_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWVDASmartContractEntryCell_Accessor>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = m_accessor_enumerable.AsQueryable<TDWVDASmartContractEntryCell_Accessor>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWVDASmartContractEntryCell_Accessor_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWVDASmartContractEntryCell_Accessor>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWVDASmartContractEntryCell_Accessor> query_tree_gen       = new IndexQueryTreeGenerator<TDWVDASmartContractEntryCell_Accessor>("TDWVDASmartContractEntryCell", Index.s_AccessorSubstringIndexAccessMethod, is_cell: false);
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
    internal class TDWVDASmartContractEntryCell_local_query_provider : IQueryProvider
    {
        private static  Type                             s_cell_type        = typeof(TDWVDASmartContractEntryCell);
        private static  Type                             s_ienumerable_type = typeof(IEnumerable<>);
        private         TDWVDASmartContractEntryCell_Enumerable           s_cell_enumerable;
        internal TDWVDASmartContractEntryCell_local_query_provider(LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            s_cell_enumerable = new TDWVDASmartContractEntryCell_Enumerable(storage, tx);
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) == s_cell_type)
            {
                return (IQueryable<TElement>)new TDWVDASmartContractEntryCell_local_selector(this, expression);
            }
            else
            {
                return new TDWVDASmartContractEntryCell_local_projector<TElement>(this, expression);
            }
        }
        public TResult Execute<TResult>(Expression expression)
        {
            var  visitor              = new RewritableWhereCaluseVisitor<TDWVDASmartContractEntryCell>(expression);
            var  where_clauses        = visitor.RewritableWhereClauses;
            var  queryable            = s_cell_enumerable.AsQueryable<TDWVDASmartContractEntryCell>();
            var  trimmed_expression   = visitor.InjectEnumerator(expression, queryable, typeof(TDWVDASmartContractEntryCell_local_selector));
            if (where_clauses.Count != 0)
            {
                var subject_rewriter           = new PredicateSubjectRewriter<TDWVDASmartContractEntryCell>();
                Expression aggregated_predicate = subject_rewriter.Visit(where_clauses.First().Body);
                foreach (var where_clause in where_clauses.Skip(1))
                {
                    Expression predicate = where_clause.Body;
                    aggregated_predicate = Expression.AndAlso(aggregated_predicate, subject_rewriter.Visit(predicate));
                }
                IndexQueryTreeGenerator<TDWVDASmartContractEntryCell> query_tree_gen       = new IndexQueryTreeGenerator<TDWVDASmartContractEntryCell>("TDWVDASmartContractEntryCell", Index.s_CellSubstringIndexAccessMethod, is_cell: true);
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
    /// Implements System.Linq.IQueryable{TDWVDASmartContractEntryCell_Accessor} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWVDASmartContractEntryCell_Accessor_local_selector : IQueryable<TDWVDASmartContractEntryCell_Accessor>
    {
        private         Expression                                   query_expression;
        private         TDWVDASmartContractEntryCell_Accessor_local_query_provider    query_provider;
        private TDWVDASmartContractEntryCell_Accessor_local_selector() { /* nobody should reach this method */ }
        internal TDWVDASmartContractEntryCell_Accessor_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWVDASmartContractEntryCell_Accessor_local_query_provider(storage, tx);
        }
        internal unsafe TDWVDASmartContractEntryCell_Accessor_local_selector(TDWVDASmartContractEntryCell_Accessor_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<CellAccessor> interfaces
        public IEnumerator<TDWVDASmartContractEntryCell_Accessor> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWVDASmartContractEntryCell_Accessor>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWVDASmartContractEntryCell_Accessor); }
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
        public PLINQWrapper<TDWVDASmartContractEntryCell_Accessor> AsParallel()
        {
            return new PLINQWrapper<TDWVDASmartContractEntryCell_Accessor>(this);
        }
        #endregion
    }
    /// <summary>
    /// Implements System.Linq.IQueryable{TDWVDASmartContractEntryCell} and accepts LINQ
    /// queries on <see cref="Trinity.Global.LocalStorage"/>.
    /// </summary>
    public class TDWVDASmartContractEntryCell_local_selector : IQueryable<TDWVDASmartContractEntryCell>, IOrderedQueryable<TDWVDASmartContractEntryCell>
    {
        private         Expression                                   query_expression;
        private         TDWVDASmartContractEntryCell_local_query_provider             query_provider;
        private TDWVDASmartContractEntryCell_local_selector() { /* nobody should reach this method */ }
        internal TDWVDASmartContractEntryCell_local_selector(Trinity.Storage.LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            this.query_expression              = Expression.Constant(this);
            this.query_provider                = new TDWVDASmartContractEntryCell_local_query_provider(storage, tx);
        }
        internal unsafe TDWVDASmartContractEntryCell_local_selector(TDWVDASmartContractEntryCell_local_query_provider query_provider, Expression query_expression)
        {
            this.query_expression              = query_expression;
            this.query_provider                = query_provider;
        }
        #region IQueryable<Cell> interfaces
        public IEnumerator<TDWVDASmartContractEntryCell> GetEnumerator()
        {
            return Provider.Execute<IEnumerator<TDWVDASmartContractEntryCell>>(query_expression);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<TDWVDASmartContractEntryCell>)this.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TDWVDASmartContractEntryCell); }
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
        /// Enumerates all the TDWVDAAccountEntryCell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDAAccountEntryCell within the local memory storage.</returns>
        public static TDWVDAAccountEntryCell_local_selector TDWVDAAccountEntryCell_Selector(this LocalMemoryStorage storage)
        {
            return new TDWVDAAccountEntryCell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWVDAAccountEntryCell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDAAccountEntryCell_Accessor within the local memory storage.</returns>
        public static TDWVDAAccountEntryCell_Accessor_local_selector TDWVDAAccountEntryCell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TDWVDAAccountEntryCell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWVDAAccountEntryCell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDAAccountEntryCell within the local memory storage.</returns>
        public static TDWVDAAccountEntryCell_local_selector TDWVDAAccountEntryCell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWVDAAccountEntryCell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TDWVDAAccountEntryCell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDAAccountEntryCell_Accessor within the local memory storage.</returns>
        public static TDWVDAAccountEntryCell_Accessor_local_selector TDWVDAAccountEntryCell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWVDAAccountEntryCell_Accessor_local_selector(storage, tx);
        }
        
        /// <summary>
        /// Enumerates all the TDWVDASmartContractEntryCell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDASmartContractEntryCell within the local memory storage.</returns>
        public static TDWVDASmartContractEntryCell_local_selector TDWVDASmartContractEntryCell_Selector(this LocalMemoryStorage storage)
        {
            return new TDWVDASmartContractEntryCell_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWVDASmartContractEntryCell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDASmartContractEntryCell_Accessor within the local memory storage.</returns>
        public static TDWVDASmartContractEntryCell_Accessor_local_selector TDWVDASmartContractEntryCell_Accessor_Selector(this LocalMemoryStorage storage)
        {
            return new TDWVDASmartContractEntryCell_Accessor_local_selector(storage, null);
        }
        /// <summary>
        /// Enumerates all the TDWVDASmartContractEntryCell within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDASmartContractEntryCell within the local memory storage.</returns>
        public static TDWVDASmartContractEntryCell_local_selector TDWVDASmartContractEntryCell_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWVDASmartContractEntryCell_local_selector(storage, tx);
        }
        /// <summary>
        /// Enumerates all the TDWVDASmartContractEntryCell_Accessor within the local memory storage.
        /// </summary>
        /// <param name="storage">A <see cref="Trinity.Storage.LocalMemoryStorage"/> object.</param>
        /// <returns>All the TDWVDASmartContractEntryCell_Accessor within the local memory storage.</returns>
        public static TDWVDASmartContractEntryCell_Accessor_local_selector TDWVDASmartContractEntryCell_Accessor_Selector(this LocalMemoryStorage storage, LocalTransactionContext tx)
        {
            return new TDWVDASmartContractEntryCell_Accessor_local_selector(storage, tx);
        }
        
    }
}

#pragma warning restore 162,168,649,660,661,1522

export interface Paginated<T> {
    page: number;
    pageSize: number;
    pageCount: number;
    totalCount: number;
    itemCount: number;
    items: T[];
}
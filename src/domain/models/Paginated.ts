import {PaginationMetadata} from "./PaginationMetadata";

export interface Paginated<T> extends PaginationMetadata{
    itemCount: number;
    items: T[];
}
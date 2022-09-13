import {PaginatedRequest} from "../../domain/requests";
import {Paginated, PaginationMetadata} from "../../domain/models";
import {useEffect, useState} from "react";

export interface PaginationParameters<T> {
    initialize?: boolean;
    loadItemsFunc: (request: PaginatedRequest) => Promise<Paginated<T>>;
    pageSize: number;
}

export interface PaginationState<T> {
    allItems: T[];
    itemsRemaining: boolean;
    meta?: PaginationMetadata;

    next(): Promise<void>

    invalidate(): Promise<void>;
}

interface Page<T> {
    number: number;
    items: T[];
}

function usePagination<T>(parameters: PaginationParameters<T>): PaginationState<T> {
    const [pages, setPages] = useState<Page<T>[]>([]);
    const [meta, setMeta] = useState<PaginationMetadata>();
    const [currentPage, setCurrentPage] = useState<number>(0);
    const itemsRemaining = !meta?.pageCount || currentPage >= meta.pageCount;
    useEffect(() => {
        if (parameters.initialize) {
            next()
        }
    }, []);

    async function next(): Promise<void> {
        if (!itemsRemaining) {
            throw Error("Can not fetch more items.")
        }
        const page = currentPage + 1;
        // eslint-disable-next-line @typescript-eslint/no-unused-vars
        const {items, itemCount, ...metadata} = await parameters.loadItemsFunc({
            page,
            pageSize: parameters.pageSize
        })
        setMeta(metadata);
        setPages((prev) => [...prev, {items, number: page}]);
        setCurrentPage(page);
    }

    async function invalidate(): Promise<void> {
        setPages([]);
        setMeta(undefined);
        setCurrentPage(0);
        await next();
    }

    return {
        allItems: pages.flatMap(x => x.items),
        itemsRemaining,
        next,
        meta,
        invalidate
    };
}

export default usePagination;
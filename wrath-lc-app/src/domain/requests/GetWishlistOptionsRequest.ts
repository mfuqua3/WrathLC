import {PaginatedRequest} from "./PaginatedRequest";

export interface GetWishlistOptionsRequest extends Partial<PaginatedRequest>{
    filter: string;
    characterId: number;
}


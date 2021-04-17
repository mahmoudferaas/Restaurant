export interface PaginatedResponseModel {
    data: any[];
    pageNumber: number;
    pageSize: number;
    count: number;
    totalCount: number;
    totalPages: number;
    hasPreviousPage: boolean;
    hasNextPage: boolean;
    nextPageNumber: number;
    previousPageNumber: number;
}

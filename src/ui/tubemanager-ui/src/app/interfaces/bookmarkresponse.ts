import { Bookmark } from "./bookmark";

export interface BookmarkResponse {
    pageNo: number;
    pageSize: number;
    totalRecords: number;
    totalPages: number;
    data: Bookmark[];
}
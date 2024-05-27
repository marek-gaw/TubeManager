import { Category } from "./category";
import { Tags } from "./tags";

export interface Bookmark {
    id: string;
    title: string;
    channel: string;
    videoUrl: string;
    description: string;
    thumbnailUrl: string;
    tags: Tags[];
    category: Category;
  }
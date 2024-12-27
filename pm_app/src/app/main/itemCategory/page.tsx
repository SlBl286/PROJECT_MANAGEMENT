"use client";
import { Button } from "@/components/ui/button";
import {
  Pagination,
  PaginationContent,
  PaginationEllipsis,
  PaginationItem,
  PaginationLink,
} from "@/components/ui/pagination";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { useGetItemCategoriesPaged } from "@/features/item-category/api/use-get-item-categories-paged";
import { columns } from "@/features/item-category/components/columns";
import CreateItemCategoryModal from "@/features/item-category/components/create-item-catetory-modal";
import { DataTable } from "@/features/item-category/components/data-table";
import { useDataTable } from "@/hooks/use-data-table";
import { useHeaderSearch } from "@/hooks/use-header-search";
import { getCoreRowModel, useReactTable } from "@tanstack/react-table";
import { MoreVertical } from "lucide-react";
const ItemCategoryPage = () => {
  const {keyword} = useHeaderSearch()
  const { pageSize, pageIndex, setPagination } =
    useDataTable();
  const { data } = useGetItemCategoriesPaged({
    keyword,
    pageIndex,
    pageSize,
  });

  const table = useReactTable({
    columns: columns,
    data: data?.items ?? [],
    manualPagination: true,
    getCoreRowModel: getCoreRowModel(),
    rowCount: data?.total,
    state: {
      pagination: {
        pageIndex,
        pageSize,
      },
    },
  });

  return (
    <div>
      <div className="mb-4 font-semibold text-2xl px-2">Danh mục hàng hoá</div>
      <div className="flex flex-row justify-between px-2">
       
        <div className="flex flex-row gap-x-2 ">
          <CreateItemCategoryModal />
          <Button variant={"outline"} size={"icon"}>
            <MoreVertical />
          </Button>
        </div>
      </div>
      <div className="mt-4 px-2">
        <DataTable table={table} />
        <div className="flex justify-center  items-center md:justify-between flex-col  md:flex-row w-full ">
          <div className="flex flex-row w-full items-center gap-x-1">
            <Select
              defaultValue={pageSize.toString()}
              onValueChange={(value) =>
                setPagination({
                  pageIndex: pageIndex > (data?.pageCount ?? 0) ? pageIndex : 0,
                  pageSize: Number(value),
                })
              }
              value={pageSize.toString()}
            >
              <SelectTrigger className="w-[60px]">
                <SelectValue placeholder="Số bản ghi" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="2">2</SelectItem>
                <SelectItem value="5">5</SelectItem>
                <SelectItem value="10">10</SelectItem>
                <SelectItem value="15">15</SelectItem>
                <SelectItem value="20">20</SelectItem>
              </SelectContent>
            </Select>
            <div> / trang</div>
            <div>
              ( hiển thị<strong> {data?.items.length} </strong> trong{" "}
              <strong> {data?.total} </strong> bản ghi )
            </div>
          </div>
          <Pagination className="flex justify-end w-full">
            <PaginationContent>
              <PaginationItem className="hover:cursor-pointer">
                <PaginationLink
                  className="text-primary"
                  onClick={() => setPagination({ pageIndex: 0, pageSize })}
                >
                  {"<<"}
                </PaginationLink>
              </PaginationItem>
              <PaginationItem className="hover:cursor-pointer">
                <PaginationLink
                  className="text-primary"
                  onClick={() => {
                    if (pageIndex > 0)
                      setPagination({ pageIndex: pageIndex - 1, pageSize });
                  }}
                >
                  {"<"}
                </PaginationLink>
              </PaginationItem>
              {[...Array(data?.pageCount).keys()].map((v, i) => {
                return (
                  <PaginationItem key={i} className="hover:cursor-pointer">
                    <PaginationLink
                      className="text-primary"
                      isActive={pageIndex == i}
                      onClick={() => {
                        setPagination({ pageSize: pageSize, pageIndex: i });
                      }}
                    >
                      {i + 1}
                    </PaginationLink>
                  </PaginationItem>
                );
              })}

              <PaginationItem className="hover:cursor-pointer">
                <PaginationLink
                  className="text-primary"
                  onClick={() => {
                    if (pageIndex < (data?.pageCount ?? 0) - 1)
                      setPagination({ pageIndex: pageIndex + 1, pageSize });
                  }}
                >
                  {">"}
                </PaginationLink>
              </PaginationItem>
              <PaginationItem className="hover:cursor-pointer">
                <PaginationLink
                  className="text-primary"
                  onClick={() =>
                    setPagination({
                      pageIndex: (data?.pageCount ?? 1) - 1,
                      pageSize,
                    })
                  }
                >
                  {">>"}
                </PaginationLink>
              </PaginationItem>
            </PaginationContent>
          </Pagination>
        </div>
      </div>
    </div>
  );
};

export default ItemCategoryPage;

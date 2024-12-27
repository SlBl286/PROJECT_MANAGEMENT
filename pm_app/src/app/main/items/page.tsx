import { useGetItems } from "@/features/items/api/use-get-items";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { MoreVertical } from "lucide-react";
import { useGetItemCategories } from "@/features/item-category/api/use-get-item-categories";
import { Badge } from "@/components/ui/badge";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { cn } from "@/lib/utils";
import test from "@/assets/react.svg";
import { useState } from "react";
import CreateItemModal from "@/features/items/components/create-item-modal";
import { useGetUnit } from "@/features/units/api/use-get-unit";
function ItemPage() {
  const [categoryId, setCategoryId] = useState<string | null>(null);
  const { data: categories } = useGetItemCategories();
  const { data: items } = useGetItems({ keyword: "",categoryId });
  return (
    <div className="w-full">
      <div className="flex gap-x-2 gap-y-2 flex-wrap">
        {categories?.items.map((c) => (
          <Badge
            key={c.id}
            onClick={() => {
              setCategoryId(c.id);
            }}
            className={cn(
              c.id === categoryId
                ? "bg-blue-300 text-blue-600"
                : "bg-gray-200 text-gray-400",
              "hover:cursor-pointer h-8 hover:bg-blue-500"
            )}
          >
            <Avatar className="bg-transparent">
              <AvatarImage
                className="bg-transparent object-contain p-2"
                src={test}
                alt={c.code}
              />
              <AvatarFallback className="bg-transparent font-bold">
                {c.name.charAt(0).toUpperCase()}
              </AvatarFallback>
            </Avatar>
            {c.name}
          </Badge>
        ))}
              <CreateItemModal />
      </div>
      <div className="grid-cols-1 md:grid-cols-3 lg:grid-cols-4">
        {items?.map((item) => {
          return (
            <div className="flex flex-col items-center justify-center gap-y-1" key={item.id}>
              <Avatar className="h-52 w-52">
                <AvatarImage
                  className="bg-transparent object-contain p-2"
                  src={test}
                  alt={item.code}
                />
                <AvatarFallback className="bg-transparent font-bold">
                  {item.name.charAt(0).toUpperCase()}
                </AvatarFallback>
              </Avatar>
              <span className="font-bold text-xl">{item.name}</span>
              <span className="font-semibold text-blue-400">{Intl.NumberFormat("vi-VN",{
                style: "currency",
                currency: "VND"
              }).format(item.retailPrice)}</span>
              <div>Còn <strong>0</strong> {item.unitName} trong kho</div>
            </div>
          );
        })}
      </div>

    </div>
  );
}

export default ItemPage;

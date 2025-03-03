"use client";

import * as React from "react";
import { Check, ChevronsUpDown, X } from "lucide-react";

import { cn } from "@/lib/utils";
import { Button } from "@/components/ui/button";
import {
  Command,
  CommandEmpty,
  CommandGroup,
  CommandInput,
  CommandItem,
  CommandList,
} from "@/components/ui/command";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import { Badge } from "./ui/badge";

export type MultiSelectOption = {
  value: string;
  label: string;
};
interface MultiSelectProps {
  options: MultiSelectOption[];
  selected: string[];
  onChange: (options: string[]) => void;
  onOpen?: (state: boolean) => void;
  className?: string;
}
export function MultiSelect({
  options,
  selected,
  onChange,
  onOpen,
  className,
}: MultiSelectProps) {
  const [open, setOpen] = React.useState(false);
  const handleUnselect = (option: string) => {
    onChange(selected.filter((item) => item !== option));
  };
  return (
    <Popover
      open={open}
      onOpenChange={(state) => {
        if (onOpen) onOpen(state);
        setOpen(state);
      }}
    >
      <PopoverTrigger asChild>
        <Button
          variant="outline"
          size={"sm"}
          role="combobox"
          aria-expanded={open}
          className="w-full justify-between p-2 h-10"
        >
          <div className="flex flex-wrap gap-1">
            {selected.map((sOpt) => (
              <Badge key={sOpt} variant="secondary" className="m-0 p-0 pl-1">
                {options.find((o) => o.value === sOpt)?.label ?? sOpt}
                <button
                  className="ml-1 rounded-xl bg-transparent"
                  onKeyDown={(e) => {
                    if (e.key === "Enter") {
                      handleUnselect(sOpt);
                    }
                  }}
                  onMouseDown={(e) => {
                    e.preventDefault();
                    e.stopPropagation();
                  }}
                  onClick={() => handleUnselect(sOpt)}
                >
                  <X className="h-3 w-3 text-muted-foreground hover:text-foreground" />
                </button>
              </Badge>
            ))}
          </div>
          <ChevronsUpDown className="ml-2 h-4 w-4 shrink-0 opacity-50" />
        </Button>
      </PopoverTrigger>
      <PopoverContent className="w-[200px] p-0">
        <Command>
          <CommandInput placeholder="Tìm framework..." />
          <CommandList>
            <CommandEmpty>Không có dữ liệu.</CommandEmpty>
            <CommandGroup>
              {options.map((o) => (
                <CommandItem
                  key={o.value}
                  onSelect={() => {
                    onChange(
                      selected.some((item) => item === o.value)
                        ? selected.filter((item) => item !== o.value)
                        : [...selected, o.value]
                    );
                    setOpen(false);
                  }}
                >
                  <Check
                    className={cn(
                      "mr-2 h-4 w-4",
                      selected.includes(o.value) ? "opacity-100" : "opacity-0"
                    )}
                  />
                  {o.label}
                </CommandItem>
              ))}
            </CommandGroup>
          </CommandList>
        </Command>
      </PopoverContent>
    </Popover>
  );
}

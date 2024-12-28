import { create } from "zustand";

type ModalStore = {
  isOpen: boolean;
  open: () => void;
  close: () => void;
  toggle: () => void;
};

export const useModal = create<ModalStore>((set) => ({
  isOpen: true,
  open: () => {
    set(() => ({ isOpen: true }));
  },
  close: () => {
    set(() => ({ isOpen: false }));
  },
  toggle: () => {
    set((state) => ({ isOpen: !state.isOpen }));
  },
}));

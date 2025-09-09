import { Box, Button, TextField } from "@mui/material";
import React, { useState } from "react";

interface Transaction {
  id: string;
  amount: number;
  description: string;
}

function Transaccion() {
  const [transaction, setTransactions] = useState<Transaction[]>([]);
  const [form, setForm] = useState({
    description: "",
    amount: "",
    id: "",
  });

  const day = new Date();
  const formatDate = day.toLocaleDateString("es-Es");

  const addTransaction = (): Transaction => {
    const newTransaction: Transaction = {
      id: formatDate,
      amount: Number(form.amount),
      description: form.description,
    };

    setTransactions((prev) => {
      if (prev.some((t) => t.id === newTransaction.id)) return prev;
      return [...prev, newTransaction];
    });

    setForm({ description: "", amount: "", id: "" });

    return newTransaction;
  };

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setForm((prev) => ({ ...prev, [name]: value }));
  };
  return (
    <Box>
      <Box
        sx={{
          display: "flex",
          justifyContent: "space-between",
        }}
      >
        <TextField
          name="description"
          placeholder="descripcion"
          value={form.description}
          onChange={handleChange}
          sx={{
            width: "100%",
            px: 2,
          }}
        />
        <TextField
          name="amount"
          placeholder="Monto"
          value={form.amount}
          onChange={handleChange}
          sx={{
            width: "100%",
            px: 2,
          }}
        />

        <Button onClick={addTransaction} variant="contained" color="secondary">
          Agregar
        </Button>
      </Box>
      <Box
        sx={{
          border: "2px solid black",
          minHeight: 400,
          height: "auto",
          mt: "2rem",
        }}
      >
        <Box
          sx={{
            padding: "10px",
          }}
        >
          {transaction.map((t) => (
            <Box
              sx={{
                width: "100%",
                display: "flex",
                justifyContent: "space-around",
                listStyle: "none",
              }}
            >
              <li>{t.description}</li>
              <li>${t.amount}</li>
              <li>{t.id}</li>
            </Box>
          ))}
        </Box>
      </Box>
    </Box>
  );
}

export default Transaccion;

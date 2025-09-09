import { Box, Button, TextField } from "@mui/material";
import { useState } from "react";

interface Transaction {
  id: number;
  amount: number;
  description: string;
}

function Transaccion() {
  const [transaction, setTransactions] = useState<Transaction[]>([]);

  const addTransaction = (transaction: Transaction): void => {
    setTransactions((prev) => [...prev, transaction]);
    console.log("Transacción agregada:", transaction);
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
          sx={{
            width: "100%",
            px: 2,
          }}
        />
        <Button
          onClick={() => {
            addTransaction({
              id: Date.now(),
              amount: 100,
              description: "Compra supermercado",
            });
          }}
          variant="contained"
          color="secondary"
        >
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
        <ul>
          {transaction.map((t) => (
            <li>
              {t.description} - ${t.amount} - {t.id}
            </li>
          ))}
        </ul>
      </Box>
    </Box>
  );
}

export default Transaccion;

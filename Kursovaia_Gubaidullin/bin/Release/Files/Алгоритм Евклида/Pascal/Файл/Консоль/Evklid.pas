var
  f1, f2: text;
  a,b,nod:integer;

begin
  assign(f1, 'input3.txt');
  assign(f2, 'output.txt');
  reset(f1);
  rewrite(f2);
   read(f1, a, b);
  while (a <> 0) and (b <> 0) do
    if a > b then
      a := a mod b
    else
      b := b mod a;
  nod := a + b;
  writeln(f2, nod);
  close(f1);
  close(f2);
end.
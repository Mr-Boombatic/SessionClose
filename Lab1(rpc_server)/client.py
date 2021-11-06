import xmlrpc.client

s = xmlrpc.client.ServerProxy('http://localhost:3000')
print(s.mul(2, 3))
print(s.add(2, 3))

print(s.system.listMethods())
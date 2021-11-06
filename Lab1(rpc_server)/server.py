from xmlrpc.server import SimpleXMLRPCServer
import os

server = SimpleXMLRPCServer(('localhost', 3000), logRequests=True)

def list_directory(dir):
    return os.listdir(dir)

class MyFuncs:
    def mul(self, x, y):
        return x * y
    def add(self, x, y):
        return x + y

server.register_introspection_functions()
server.register_function(list_directory)
server.register_instance(MyFuncs())

if __name__ == '__main__':
    try:
        print('Serving...')
        server.serve_forever()
    except KeyboardInterrupt:
        print('Exiting')

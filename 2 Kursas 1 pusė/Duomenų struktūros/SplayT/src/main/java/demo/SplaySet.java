package demo;

import java.util.Iterator;
import java.util.Stack;
public class SplaySet<E extends Comparable<E>> implements Iterable<E>{

    protected Node<E> root;

    public SplaySet(){
        this.root = null;
    }


    public boolean isEmpty() {
        return root == null;
    }

    public boolean contains(E element){
        return get(element) != null;
    }

    public int size(){
        return size(root);
    }

    public int height(){
        return height(root);
    }

    private int height(Node node){
        if (node == null){
            return -1;
        }
        else{
            return 1 + Math.max(height(node.left), height(node.right));
        }
    }

    private int size(Node node){
        if (node == null){
            return 0;
        }
        else{
            return 1 + size(node.left) + size(node.right);
        }
    }
    public void put(E element){
        if (root == null){
            root = new Node(element);
            return;
        }

        root = splay(root, element);

        int cmp = element.compareTo(root.key);

        if (cmp < 0){
            Node n = new Node(element);
            n.left = root.left;
            n.right = root;
            root.left = null;
            root = n;
        }
        else if (cmp > 0){
            Node n = new Node(element);
            n.right = root.right;
            n.left = root;
            root.right = null;
            root = n;
        }
        else{
            root.key = element;
        }
    }

    private Node splay(Node node, E element){
        if (node == null){
            return null;
        }

        int cmp1 = element.compareTo((E)node.key);

        if (cmp1 < 0){
            if (node.left == null){
                return node;
            }

            int cmp2 = element.compareTo((E)node.left.key);
            if (cmp2 < 0){
                node.left.left = splay(node.left.left, element);
                node = rotateRight(node);
            }
            else if (cmp2 > 0){
                node.left.right = splay(node.left.right, element);
                if (node.left.right != null){
                    node.left = rotateLeft(node.left);
                }
            }
            if (node.left == null){
                return node;
            }
            else return rotateRight(node);
        }
        else if (cmp1 > 0){
            if (node.right == null){
                return node;
            }

            int cmp2 = element.compareTo((E)node.right.key);
            if (cmp2 < 0){
                node.right.left = splay(node.right.left, element);
                if (node.right.left != null){
                    node.right = rotateRight(node.right);
                }
            }
            else if (cmp2 > 0){
                node.right.right = splay(node.right.right, element);
                node = rotateLeft(node);
            }
            if (node.right == null){
                return node;
            }
            else return rotateLeft(node);
        }
        else return node;
    }


    public E get(E element){
        root = splay(root, element);
        int cmp = element.compareTo(root.key);
        if (cmp == 0){
            return root.key;
        }
        else return null;
    }

    public void remove(E element){
        if (root == null){
            return;
        }

        root = splay(root, element);

        int cmp = element.compareTo(root.key);
        if (cmp == 0){
            if (root.left == null){
                root = root.right;
            }
            else{
                Node x = root.right;
                root = root.left;
                root = splay(root, element);
                root.right = x;
            }
        }
    }

    private Node rotateRight(Node node){
        Node<E> x = node.left;
        node.left = x.right;
        x.right = node;
        return x;
    }

    private Node rotateLeft(Node node){
        Node x = node.right;
        node.right = x.left;
        x.left = node;
        return x;
    }

    private static final String[] term = {"\u2500", "\u2534", "\u252C", "\u253C"};
    private static final String rightEdge = "\u250C";
    private static final String leftEdge = "\u2514";
    private static final String endEdge = "\u25CF";
    private static final String vertical = "\u2502  ";
    private String horizontal;

    public String toVisualizedString(String dataCodeDelimiter) {
        horizontal = term[0] + term[0];
        return root == null ? ">" + horizontal
                : toTreeDraw(root, ">", "", dataCodeDelimiter);
    }

    private String toTreeDraw(Node<E> node, String edge, String indent, String dataCodeDelimiter) {
        if (node == null) {
            return "";
        }
        String step = (edge.equals(leftEdge)) ? vertical : "   ";
        StringBuilder sb = new StringBuilder();
        sb.append(toTreeDraw(node.right, rightEdge, indent + step, dataCodeDelimiter));
        int t = (node.right != null) ? 1 : 0;
        t = (node.left != null) ? t + 2 : t;
        sb.append(indent).append(edge).append(horizontal).append(term[t]).append(endEdge).append(
                split(node.key.toString(), dataCodeDelimiter)).append(System.lineSeparator());
        step = (edge.equals(rightEdge)) ? vertical : "   ";
        sb.append(toTreeDraw(node.left, leftEdge, indent + step, dataCodeDelimiter));
        return sb.toString();
    }

    private String split(String s, String dataCodeDelimiter) {
        int k = s.indexOf(dataCodeDelimiter);
        if (k <= 0) {
            return s;
        }
        return s.substring(0, k);
    }

    @Override
    public Iterator<E> iterator() {
        return new IteratorSplayTree(true);
    }

    private class IteratorSplayTree implements Iterator<E> {

        private final Stack<Node<E>> stack = new Stack<>();
        // Nurodo iteravimo kolekcija kryptį, true - didėjimo tvarka, false - mažėjimo
        private final boolean ascending;

        public IteratorSplayTree(boolean ascendingOrder) {
            this.ascending = ascendingOrder;
            this.toStack(root);
        }

        @Override
        public boolean hasNext() {
            return !stack.empty();
        }

        @Override
        public E next() {// Jei stekas tuščias
            if (stack.empty()) {
                return null;
            } else {

                Node<E> n = stack.pop();

                Node<E> node = ascending ? n.right : n.left;

                toStack(node);
                return n.key;
            }
        }

        private void toStack(Node<E> node) {
            while (node != null) {
                stack.push(node);
                node = ascending ? node.left : node.right;
            }
        }
    }

    protected class Node<E>
    {
        protected E key;          // The data in the node
        protected Node<E> left;         // Left child
        protected Node<E> right;        // Right child

        protected Node(E theKey) {
            key = theKey;
            left = right = null;
        }


    }
}
